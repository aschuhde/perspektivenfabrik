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
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-input-location',
  imports: [MatIcon, MatFormField, MatSelect, MatLabel, MatOption, MatInput, FormsModule, TranslateModule],
  templateUrl: './input-location.component.html',
  styleUrl: './input-location.component.scss'
})
export class InputLocationComponent {
  readonly dialog = inject(MatDialog);

  location = model.required<LocationInput>();
  locationIndex = model.required<number>();
  remove = output<LocationInput>();
  onChanged = output();

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
  get locationName(){
    return this.location().locationName
  }
  set locationName(value: string){
    this.location().locationName = value
      this.onChanged.emit();
  }
  get locationDisplayName(){
    return this.location().locationDisplayName
  }
  set locationDisplayName(value: string){
    this.location().locationDisplayName = value
    this.onChanged.emit();
  }
  get locationAddress(){
    return this.location().locationAddress
  }
  set locationAddress(value: string){
    this.location().locationAddress = value
      this.onChanged.emit();
  }
  get locationAddressDisplayName(){
    return this.location().locationAddressDisplayName
  }
  set locationAddressDisplayName(value: string){
    this.location().locationAddressDisplayName = value
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
      message: "Todo: Beschreibung, wozu link gut sein kann",
      title: "Link für Remote-Ort"
    }),
    helpLocationName: new MessageDialogData({
      message: "Todo: Der Name kann ein Dorf, ein Platz, eine Region etc... sein",
      title: "Name eines Ortes"
    }),
    helpLocationAddress: new MessageDialogData({
      message: "Todo: Beschreibung zu Adresse",
      title: "Adresse"
    }) ,
    helpLocationCoordinates: new MessageDialogData({
      message: "Todo: Beschreibung zu Koordinaten",
      title: "Koordinaten"
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
        onApply: (value: string, displayName: string) => {
          this.mapRetrievedPoint(value, displayName);
        }
      }
    });
  }

  mapRetrievedPoint(value: string, displayName: string){
    switch(this.locationType){
      case "address":
        this.locationAddress = value;
        this.locationAddressDisplayName = displayName;
        break;
      case "coordinates":
        this.locationCoordinates = value;
        break;
      case "name":
        this.locationName = value;
        this.locationDisplayName = displayName;
        break;
    }     
  }

}
