import { Component, model, output, inject } from '@angular/core';
import { LocationInput } from '../../models/location-input';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatOption, MatSelect } from '@angular/material/select';
import { MatDialog } from '@angular/material/dialog';
import { MessageDialogData } from '../../../../shared/models/message-dialog-data';
import { MessageDialogComponent } from '../../../../shared/dialogs/message-dialog/message-dialog.component';
import { MatInput } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MapComponent } from '../../../../shared/components/map/map.component';

@Component({
  selector: 'app-input-location',
  imports: [MatButton, MatIcon, MatFormField, MatSelect, MatLabel, MatOption, MatInput, FormsModule, MapComponent],
  templateUrl: './input-location.component.html',
  styleUrl: './input-location.component.scss'
})
export class InputLocationComponent {
  readonly dialog = inject(MatDialog);

  location = model.required<LocationInput>();
  remove = output<LocationInput>();
  locationType: "unkown" | "remote" | "name" | "address" | "coordinates" = "unkown"
  locationLink: string = ""
  locationName: string = ""
  locationAddress: string = ""
  locationCoordinates: string = ""

  get mapLookupMode(){
    if(this.locationType === "coordinates"){
      return "latLon";
    }
    if(this.locationType === "name"){
      return "poi";
    }
    return "address";
  }

  get useMap(){
    return this.locationType === "name" || this.locationType === "address" || this.locationType === "coordinates";
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

  mapRetrievedPoint(name: string){
    switch(this.locationType){
      case "address":
        this.locationAddress = name;
        break;
      case "coordinates":
        this.locationCoordinates = name;
        break;
      case "name":
        this.locationName = name;
        break;
    }
  }

}
