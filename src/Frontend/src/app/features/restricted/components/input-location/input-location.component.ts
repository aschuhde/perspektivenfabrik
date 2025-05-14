import { Component, model, output, inject } from '@angular/core';
import { LocationInput, LocationType } from '../../models/location-input';
import { MatIcon } from '@angular/material/icon';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatOption, MatSelect } from '@angular/material/select';
import { MatDialog } from '@angular/material/dialog';
import { MessageDialogData } from '../../../../shared/models/message-dialog-data';
import { MessageDialogComponent } from '../../../../shared/dialogs/message-dialog/message-dialog.component';
import { MatInput } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MapDialogComponent } from '../../../../shared/dialogs/map-dialog/map-dialog.component';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import {
    MatInputTranslationsComponent
} from "../../../../shared/components/mat-input-translations/mat-input-translations.component";
import {TranslationValue} from "../../../../shared/models/translation-value";
import {Language} from "../../../../core/types/general-types";

@Component({
  selector: 'app-input-location',
    imports: [MatIcon, MatFormField, MatSelect, MatLabel, MatOption, MatInput, FormsModule, TranslateModule, MatInputTranslationsComponent],
  templateUrl: './input-location.component.html',
  styleUrl: './input-location.component.scss'
})
export class InputLocationComponent {
  readonly dialog = inject(MatDialog);

  location = model.required<LocationInput>();
  locationIndex = model.required<number>();
  remove = output<LocationInput>();
  onChanged = output();
  translateService = inject(TranslateService)
  locationNameLanguage: Language = this.translateService.currentLang as Language;
  locationAddressLanguage: Language = this.translateService.currentLang as Language;
  locationAddressDisplayNameLanguage: Language = this.translateService.currentLang as Language;
  locationDisplayNameLanguage: Language = this.translateService.currentLang as Language;

  get locationNumber(){
    return this.locationIndex() + 1;
  }

  get locationType(){
    return this.location().locationType
  }
  set locationType(value: LocationType){
    this.location().locationType = value
      this.onChanged.emit();
  }
  get locationLink(){
    return this.location().locationLink
  }
  set locationLink(value: string){
    this.location().locationLink = value
      this.onChanged.emit();
  }
  get locationLinkTranslations(){
    return this.location().locationLinkTranslations
  }
  set locationLinkTranslations(value: TranslationValue[]){
    this.location().locationLinkTranslations = value
    this.onChanged.emit();
  }
  get locationName(){
    return this.location().locationName
  }
  set locationName(value: string){
    this.location().locationName = value
      this.onChanged.emit();
  }
  get locationNameTranslations(){
    return this.location().locationNameTranslations
  }
  set locationNameTranslations(value: TranslationValue[]){
    this.location().locationNameTranslations = value
    this.onChanged.emit();
  }
  get locationDisplayName(){
    return this.location().locationDisplayName
  }
  set locationDisplayName(value: string){
    this.location().locationDisplayName = value
    this.onChanged.emit();
  }
  get locationDisplayNameTranslations(){
    return this.location().locationDisplayNameTranslations
  }
  set locationDisplayNameTranslations(value: TranslationValue[]){
    this.location().locationDisplayNameTranslations = value
    this.onChanged.emit();
  }
  get locationAddress(){
    return this.location().locationAddress
  }
  set locationAddress(value: string){
    this.location().locationAddress = value
      this.onChanged.emit();
  }
  get locationAddressTranslations(){
    return this.location().locationAddressTranslations
  }
  set locationAddressTranslations(value: TranslationValue[]){
    this.location().locationAddressTranslations = value
    this.onChanged.emit();
  }
  get locationAddressDisplayName(){
    return this.location().locationAddressDisplayName
  }
  set locationAddressDisplayName(value: string){
    this.location().locationAddressDisplayName = value
    this.onChanged.emit();
  }
  get locationAddressDisplayNameTranslations(){
    return this.location().locationAddressDisplayNameTranslations
  }
  set locationAddressDisplayNameTranslations(value: TranslationValue[]){
    this.location().locationAddressDisplayNameTranslations = value
    this.onChanged.emit();
  }
  get locationCoordinates(){
    return this.location().locationCoordinates
  }
  set locationCoordinates(value: string){
    this.location().locationCoordinates = value
      this.onChanged.emit();
  }

  get mapLookupMode(){
    if(this.locationType === "coordinates"){
      return "latLon";
    }
    if(this.locationType === "name"){
      return "poi";
    }
    return "address";
  }
  get locationObject(){
    return this.location();
  }
  readonly messageDialogs = {
    helpLocationLink: new MessageDialogData({
      message: this.translateService.instant("messages.helpLocationLinkMessage"),
      title: this.translateService.instant("messages.helpLocationLinkTitle")
    }),
    helpLocationName: new MessageDialogData({
      message: this.translateService.instant("messages.helpLocationNameMessage"),
      title: this.translateService.instant("messages.helpLocationNameTitle")
    }),
    helpLocationAddress: new MessageDialogData({
      message: this.translateService.instant("messages.helpLocationAddressMessage"),
      title: this.translateService.instant("messages.helpLocationAddressTitle")
    }) ,
    helpLocationCoordinates: new MessageDialogData({
      message: this.translateService.instant("messages.helpLocationCoordinatesMessage"),
      title: this.translateService.instant("messages.helpLocationCoordinatesTitle")
    }) 
  };
  removeClicked(){
    this.remove.emit(this.locationObject);
  }  

  showMessageDialog(dialogData: MessageDialogData) {
    this.dialog.open(MessageDialogComponent, {
      data: dialogData
    });
  }

  showMapDialog() {
    this.dialog.open(MapDialogComponent, {
      data: {
        lookupMode: this.mapLookupMode,
        onApply: (value: string, displayName: string, valueTranslations: TranslationValue[], displayNameTranslations: TranslationValue[], mainLanguage: Language) => {
          this.mapRetrievedPoint(value, displayName, valueTranslations, displayNameTranslations, mainLanguage);
        }
      }
    });
  }

  mapRetrievedPoint(value: string, displayName: string, valueTranslations: TranslationValue[], displayNameTranslations: TranslationValue[], mainLanguage: Language){
    switch(this.locationType){
      case "address":
        this.locationAddressLanguage = mainLanguage;
        this.locationAddressDisplayNameLanguage = mainLanguage;
        this.locationAddress = value;
        this.locationAddressTranslations = valueTranslations;
        this.locationAddressDisplayName = displayName;
        this.locationAddressDisplayNameTranslations = displayNameTranslations;
        break;
      case "coordinates":
        this.locationCoordinates = value;
        break;
      case "name":
        this.locationNameLanguage = mainLanguage;
        this.locationDisplayNameLanguage = mainLanguage;
        this.locationName = value;
        this.locationNameTranslations = valueTranslations;
        this.locationDisplayName = displayName;
        this.locationDisplayNameTranslations = displayNameTranslations;
        break;
    }     
  }

}
