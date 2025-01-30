import { Component, ElementRef, inject, input, output, PLATFORM_ID, ViewChild } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { Marker } from 'leaflet';
import idGenerator from '../../tools/id-generator';


@Component({
  selector: 'app-map',
  imports: [],
  templateUrl: './map.component.html',
  styleUrl: './map.component.scss'
})
export class MapComponent {  

  platformId = inject(PLATFORM_ID);
  canUseLeaflet = isPlatformBrowser(this.platformId);
  onRetrievedPoint = output<string>();
  lookupMode = input<"latLon" | "poi" | "address">("address");
  readonly mapId = idGenerator.getId();
  @ViewChild('map')
  map!: ElementRef 
  

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
        const geocoder = C.geocoders.nominatim();
        const geocoderControl = C.geocoder({
          placeholder: "Suchen...",
          geocoder: geocoder
        });
        let marker: Marker<any> | null = null;
        const self = this;
        geocoderControl.on("markgeocode", function(e){
          marker?.remove();
          marker = null;
          if(self.lookupMode() === "latLon"){
            self.onRetrievedPoint.emit(`${e.geocode.center.lat}, ${e.geocode.center.lng}`);
            return;
          }
          self.onRetrievedPoint.emit(e.geocode.name);                    
        });      
        
        geocoderControl.addTo(map);                
        
        
        map.on('click', e => {     
          
          if(this.lookupMode() === "latLon"){          
            if (marker) {              
              marker
                .setLatLng(e.latlng)
                .setPopupContent(`${e.latlng.lat}, ${e.latlng.lng}`);                
            } else {
              marker = L.marker(e.latlng).bindPopup(`${e.latlng.lat}, ${e.latlng.lng}`).addTo(map);
            }
            this.onRetrievedPoint.emit(`${e.latlng.lat}, ${e.latlng.lng}`);
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
            this.onRetrievedPoint.emit(r.name);        
          });
        });
      })      
  });       
  }  

  afterRender() {
            
  }
}


