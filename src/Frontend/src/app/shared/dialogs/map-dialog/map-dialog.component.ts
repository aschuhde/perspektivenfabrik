import { Component, inject } from '@angular/core';
import { MapComponent } from '../../components/map/map.component';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogTitle } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';

@Component({
  selector: 'app-map-dialog',
  imports: [MatLabel, MatFormField, MatInput, FormsModule, MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, MapComponent],
  templateUrl: './map-dialog.component.html',
  styleUrl: './map-dialog.component.scss'
})
export class MapDialogComponent {
  data = inject(MAT_DIALOG_DATA);
  retrievedPoint: string = ""
  retrievedPointDisplayName: string = ""
  lookupMode = this.data?.lookupMode ?? "address";
  type: "lookup" | "display" = this.data?.type ?? "lookup";
  startPoint: string = this.data?.startPoint ?? "";
  
  ngOnInit(){
    if(this.startPoint){
      this.mapRetrievedPoint(this.startPoint);
    }
  }
  
  mapRetrievedPoint(name: string, displayName?: string){
    this.retrievedPoint = name;
    this.retrievedPointDisplayName = displayName ?? "";
  }
  apply(){
    if(!this.retrievedPoint){
      return;
    }
    if(this.data?.onApply){
      this.data.onApply(this.retrievedPoint, this.retrievedPointDisplayName);
    }
  }
}
