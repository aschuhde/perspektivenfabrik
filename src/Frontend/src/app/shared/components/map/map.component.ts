import { Component, ElementRef, inject, input, output, PLATFORM_ID, ViewChild } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import {Marker} from 'leaflet';
import idGenerator from '../../tools/id-generator';
import {CoordinatesConverter} from "../../tools/coordinates-converter";
import {formatCoordinates} from "../../tools/formatting";
import {LocaleDataProvider} from "../../../core/services/locale-data.service";
import {MobileScreenWidthBreakpoint} from "../../tools/responsive";
import {TranslationValue} from "../../models/translation-value";
import {LanguageService} from "../../../core/services/language-service.service";
import { TranslateService } from '@ngx-translate/core';
import {Language} from "../../../core/types/general-types";
import {getNominatimOsmEntry} from "../../tools/nominatim-tools";
import { HttpClient } from '@angular/common/http';


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
  onRetrievedPoint = output<{value: string, displayName: string, valueTranslations: TranslationValue[], displayNameTranslations: TranslationValue[]}>();
  lookupMode = input<"latLon" | "poi" | "address">("address");
  readonly mapId = idGenerator.getId();
  @ViewChild('map')
  map!: ElementRef 
  type = input<"lookup" | "display">("lookup")
  startPoint = input<string>("");
  translateService = inject(TranslateService)
  httpClient = inject(HttpClient)

  ngAfterViewInit() {
    if(!this.canUseLeaflet)
      return;

    const screenWidth = window.screen.width;
    
    if(screenWidth <= MobileScreenWidthBreakpoint){
     this.map.nativeElement.style.width = `${screenWidth-60}px`; 
    }
    
    import("leaflet").then(L => {
      import("leaflet-control-geocoder").then(C => {
        L.default.Icon.Default.imagePath = 'leaflet/';
        this.map.nativeElement.id = this.mapId;              
        const map = L.default.map(this.mapId);
        L.default.tileLayer('https://{s}.tile.osm.org/{z}/{x}/{y}.png', {
          attribution: '&copy; <a href="https://osm.org/copyright">OpenStreetMap</a> contributors'
        }).addTo(map);
        const bounds = L.default.latLngBounds([47.081, 10.398], [46.155, 12.543]);
  
        // Fit the map view to the bounds
        map.fitBounds(bounds);
        let marker: Marker<any> | null = null;
        const self = this;
        const geocoderDe = C.geocoders.nominatim({
          reverseQueryParams: {
            "accept-language": "de"
          },
          geocodingQueryParams: {
            "accept-language": "de"
          }
        });
        const geocoderIt = C.geocoders.nominatim({
          reverseQueryParams: {
            "accept-language": "it"
          },
          geocodingQueryParams: {
            "accept-language": "it"
          }
        });
        const preferredGeocoderLanguage = this.translateService.currentLang === "it" ? "it" : "de";
        const otherGeocoderLanguage = preferredGeocoderLanguage === "it" ? "de" : "it";
        const preferredGeocoder = this.translateService.currentLang === "it" ? geocoderIt : geocoderDe;
                      
        
        if(this.startPoint()){
          if (this.lookupMode() === "latLon") {
            const coordinates = CoordinatesConverter.TransformCoordinatesStringToApiCoordinates(this.startPoint());
            if(!coordinates || !coordinates.lat || !coordinates.lon) return;
            marker = L.default.marker({lat: coordinates.lat, lng: coordinates.lon}).bindPopup(formatCoordinates(coordinates, this.localeDataProvider.locale)).addTo(map);
            return;
          }
          preferredGeocoder.geocode(this.startPoint()).then(results => {
            if(results.length === 0) return;
            
            const r = results[0];
            marker = L.default.marker(r.center).bindPopup(r.name).addTo(map).openPopup();
          })
        }
        
        if(this.type() === "lookup") {
          const geocoderControl = C.geocoder({
            placeholder: this.translateService.instant("map.search"),
            geocoder: preferredGeocoder
          });

          geocoderControl.on("markgeocode", e => {
            marker?.remove();
            marker = null;
            if(self.lookupMode() === "latLon"){
              self.onRetrievedPoint.emit({value: `${e.geocode.center.lat}, ${e.geocode.center.lng}`, displayName: "", valueTranslations: [], displayNameTranslations: []});
              return;
            }
            self.onRetrievedPoint.emit({value: "...", displayName: "...", valueTranslations: [], displayNameTranslations: []});
            getNominatimOsmEntry(otherGeocoderLanguage, e.geocode.properties.osm_id, e.geocode.properties.osm_type, e.geocode.properties.place_id, this.httpClient).then(resultOtherGeocoder => {
              const results = this.parseGeocoderResults(e.geocode, resultOtherGeocoder, preferredGeocoderLanguage, otherGeocoderLanguage);
              self.onRetrievedPoint.emit({value: results.name, displayName: results.displayName, valueTranslations: results.valueTranslations, displayNameTranslations: results.displayNameTranslations});
            });
          });

          geocoderControl.addTo(map);
          map.on('click', e => {

            if (this.lookupMode() === "latLon") {
              if (marker) {
                marker
                  .setLatLng(e.latlng)
                  .setPopupContent(`${e.latlng.lat}, ${e.latlng.lng}`);
              } else {
                marker = L.default.marker(e.latlng).bindPopup(`${e.latlng.lat}, ${e.latlng.lng}`).addTo(map);
              }
              this.onRetrievedPoint.emit({value: `${e.latlng.lat}, ${e.latlng.lng}`, displayName: "", valueTranslations: [], displayNameTranslations: []});
              return;
            }

            preferredGeocoder.reverse(e.latlng, 67108864).then(resultsPreferredGeocoder => {
              const r = resultsPreferredGeocoder[0];

              if (marker) {
                marker
                  .setLatLng(r.center)
                  .setPopupContent(r.name).openPopup();
              } else {
                marker = L.default.marker(r.center).bindPopup(r.name).addTo(map).openPopup();
              }
              self.onRetrievedPoint.emit({value: "...", displayName: "...", valueTranslations: [], displayNameTranslations: []});
              getNominatimOsmEntry(otherGeocoderLanguage, r.properties.osm_id, r.properties.osm_type, r.properties.place_id, this.httpClient).then(resultOtherGeocoder => {
                const results = this.parseGeocoderResults(r, resultOtherGeocoder, preferredGeocoderLanguage, otherGeocoderLanguage);
                self.onRetrievedPoint.emit({value: results.name, displayName: results.displayName, valueTranslations: results.valueTranslations, displayNameTranslations: results.displayNameTranslations});
              });
            });
          });
        }
      })      
  });       
  }  

  parseGeocoderResults(r: any, r2Array: any, preferredLanguage: Language, otherLanguage: Language){
    const r2 = r2Array && r2Array.length > 0 ? {
      properties: r2Array[0],
      name: r2Array[0].display_name
    } : null;
    const displayNames = this.getDisplayName(r, r2);
    return {
      name: r.name,
      displayName: displayNames ? displayNames[0] : r.name,
      valueTranslations: r2 ? [new TranslationValue(preferredLanguage, r.name), new TranslationValue(otherLanguage, r2.name)] : [],
      displayNameTranslations: r2 && displayNames && displayNames.length > 1 ? [new TranslationValue(preferredLanguage, displayNames[0]), new TranslationValue(otherLanguage, displayNames[1])] : [],
    };
  }
  
  getDisplayName(r: any, r2: any): string[] | null{
    return this.getProperty(r, r2, (x: any) => x.properties?.address?.peak)
      ?? this.getProperty(r, r2, (x: any) => x.properties?.address?.water)
      ?? this.getProperty(r, r2, (x: any) => x.properties?.address?.gorge)
      ?? this.getProperty(r, r2, (x: any) => x.properties?.address?.river)
      ?? this.getProperty(r, r2, (x: any) => x.properties?.address?.amenity)
      ?? this.getProperty(r, r2, (x: any) => x.properties?.address?.shop)
      ?? this.getProperty(r, r2, (x: any) => x.properties?.address?.tourism)
      ?? this.getProperty(r, r2, (x: any) => x.properties?.address?.locality)
      ?? this.getProperty(r, r2, (x: any) => x.properties?.address?.village)
      ?? this.getProperty(r, r2, (x: any) => x.properties?.address?.town)
      ?? this.getProperty(r, r2, (x: any) => x.properties?.address?.city)
      ?? this.getProperty(r, r2, (x: any) => x.properties?.address?.region)
      ?? this.getProperty(r, r2, (x: any) => x.properties?.address?.municipality)
      ?? this.getProperty(r, r2, (x: any) => x.properties?.address?.state)
      ?? this.getProperty(r, r2, (x: any) => x.properties?.name)
  }
  getProperty(r1: any, r2: any, getPropertyPath: (x: any) => any): string[] | null{
    const r1Value = getPropertyPath(r1);
    if(r1Value)
      return [r1Value, getPropertyPath(r2)];
    return null;
  }
  afterRender() {
            
  }
}


