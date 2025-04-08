import { Component, ElementRef, inject, input, output, PLATFORM_ID, ViewChild } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import {Marker} from 'leaflet';
import idGenerator from '../../tools/id-generator';
import {CoordinatesConverter} from "../../tools/coordinates-converter";
import {formatCoordinates} from "../../tools/formatting";
import {LocaleDataProvider} from "../../../core/services/locale-data.service";


@Component({
  selector: 'app-map',
  imports: [],
  templateUrl: './map.component.html',
  styleUrl: './map.component.scss'
})
export class MapComponent {

  localeDataProvider = inject(LocaleDataProvider);
  platformId = inject(PLATFORM_ID);
  canUseLeaflet = isPlatformBrowser(this.platformId);
  onRetrievedPoint = output<{value: string, displayName: string}>();
  lookupMode = input<"latLon" | "poi" | "address">("address");
  readonly mapId = idGenerator.getId();
  @ViewChild('map')
  map!: ElementRef 
  type = input<"lookup" | "display">("lookup")
  startPoint = input<string>("");

  ngAfterViewInit() {
    if(!this.canUseLeaflet)
      return;

    import("leaflet").then(L => {
      import("leaflet-control-geocoder").then(C => {
        L.Icon.Default.imagePath = 'leaflet/';
        this.map.nativeElement.id = this.mapId;              
        const map = L.map(this.mapId);
        L.tileLayer('https://{s}.tile.osm.org/{z}/{x}/{y}.png', {
          attribution: '&copy; <a href="https://osm.org/copyright">OpenStreetMap</a> contributors'
        }).addTo(map);
        const bounds = L.latLngBounds([46.9539, 11.3106], [46.5568, 11.3469]);
  
        // Fit the map view to the bounds
        map.fitBounds(bounds);
        let marker: Marker<any> | null = null;
        const self = this;
        const geocoder = C.geocoders.nominatim();
                      
        
        if(this.startPoint()){
          if (this.lookupMode() === "latLon") {
            const coordinates = CoordinatesConverter.TransformCoordinatesStringToApiCoordinates(this.startPoint());
            if(!coordinates || !coordinates.lat || !coordinates.lon) return;
            marker = L.marker({lat: coordinates.lat, lng: coordinates.lon}).bindPopup(formatCoordinates(coordinates, this.localeDataProvider.locale)).addTo(map);
            return;
          }
          geocoder.geocode(this.startPoint()).then(results => {
            if(results.length === 0) return;
            
            const r = results[0];
            marker = L.marker(r.center).bindPopup(r.name).addTo(map).openPopup();
          })
        }
        
        if(this.type() === "lookup") {
          const geocoderControl = C.geocoder({
            placeholder: "Suchen...",
            geocoder: geocoder
          });

          geocoderControl.on("markgeocode", e => {
            marker?.remove();
            marker = null;
            if(self.lookupMode() === "latLon"){
              self.onRetrievedPoint.emit({value: `${e.geocode.center.lat}, ${e.geocode.center.lng}`, displayName: ""});
              return;
            }
            self.onRetrievedPoint.emit({value: e.geocode.name, displayName: this.getDisplayName(e.geocode)});
          });

          geocoderControl.addTo(map);
          map.on('click', e => {

            if (this.lookupMode() === "latLon") {
              if (marker) {
                marker
                  .setLatLng(e.latlng)
                  .setPopupContent(`${e.latlng.lat}, ${e.latlng.lng}`);
              } else {
                marker = L.marker(e.latlng).bindPopup(`${e.latlng.lat}, ${e.latlng.lng}`).addTo(map);
              }
              this.onRetrievedPoint.emit({value: `${e.latlng.lat}, ${e.latlng.lng}`, displayName: ""});
              return;
            }

            geocoder.reverse(e.latlng, 67108864).then(results => {
              const r = results[0];

              if (marker) {
                marker
                  .setLatLng(r.center)
                  .setPopupContent(r.name).openPopup();
              } else {
                marker = L.marker(r.center).bindPopup(r.name).addTo(map).openPopup();
              }
              this.onRetrievedPoint.emit({value: r.name, displayName: this.getDisplayName(r)});
            });
          });
        }
      })      
  });       
  }  

  getDisplayName(r: any): string{
    console.log(r.properties);
    return r.properties?.address?.peak
      ?? r.properties?.address?.water
      ?? r.properties?.address?.gorge
      ?? r.properties?.address?.river
      ?? r.properties?.address?.amenity
      ?? r.properties?.address?.shop
      ?? r.properties?.address?.tourism
      ?? r.properties?.address?.locality
      ?? r.properties?.address?.village
      ?? r.properties?.address?.town
      ?? r.properties?.address?.city
      ?? r.properties?.address?.region
      ?? r.properties?.address?.municipality
      ?? r.properties?.address?.state
      ?? r.properties?.name;
  }
  afterRender() {
            
  }
}


