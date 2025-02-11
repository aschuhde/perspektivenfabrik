import { ENTER, COMMA, TAB } from '@angular/cdk/keycodes';
import { Component, inject, model } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatAutocompleteModule, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatChipsModule, MatChipInputEvent } from '@angular/material/chips';
import { MatOption } from '@angular/material/core';
import { MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatIcon } from '@angular/material/icon';
import { MatInput } from '@angular/material/input';
import { MatSlideToggle } from '@angular/material/slide-toggle';
import { SelectOptionMaterial } from '../../../../shared/models/select-option-material';
import { InputLocationComponent } from '../../components/input-location/input-location.component';
import { InputProjectTimeComponent } from '../../components/input-project-time/input-project-time.component';
import { LocationInput } from '../../models/location-input';
import { ProjectTimeInput } from '../../models/project-time-input';
import { RequirementMaterialInput } from '../../models/requirement-material-input';

@Component({
  selector: 'app-edit-requirement-material',
  imports: [FormsModule, MatFormField, MatLabel, MatInput, MatIcon, MatOption, MatAutocompleteModule, MatChipsModule, MatSlideToggle, InputProjectTimeComponent, InputLocationComponent, MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose],
  templateUrl: './edit-requirement-material.component.html',
  styleUrl: './edit-requirement-material.component.scss'
})
export class EditRequirementMaterialComponent { 
  data = inject(MAT_DIALOG_DATA);
  readonly dialog = inject(MatDialog);
  readonly addOnBlur = false;
  readonly separatorKeysCodes = [ENTER, COMMA, TAB] as const;
  requirementMaterial: RequirementMaterialInput = this.data?.requirementMaterial;

  materialAutocompleteValue = model("");
  materialOptions: SelectOptionMaterial[] = [new SelectOptionMaterial("Holz"), new SelectOptionMaterial("Biertischganituren"), new SelectOptionMaterial("Elektroschrott")];
  requirementIndex: number = this.data?.requirementIndex;

  get requirementNumber(){
    return this.requirementIndex + 1;
  }

  get selectedMaterials(){
    return this.requirementMaterial.selectedMaterials
  }
  set selectedMaterials(value: SelectOptionMaterial[]){
    this.requirementMaterial.selectedMaterials = value
  }
  get requirementTimeIsIdenticalToProjectTime(){
    return this.requirementMaterial.requirementTimeIsIdenticalToProjectTime
  }
  set requirementTimeIsIdenticalToProjectTime(value: boolean){
    this.requirementMaterial.requirementTimeIsIdenticalToProjectTime = value
  }
  get requirementTimes(){
    return this.requirementMaterial.requirementTimes
  }
  set requirementTimes(value: ProjectTimeInput[]){
    this.requirementMaterial.requirementTimes = value
  }
  get requirementLocationIsIdenticalToProjectLocation(){
    return this.requirementMaterial.requirementLocationIsIdenticalToProjectLocation
  }
  set requirementLocationIsIdenticalToProjectLocation(value: boolean){
    this.requirementMaterial.requirementLocationIsIdenticalToProjectLocation = value
  }
  get requirementLocations(){
    return this.requirementMaterial.requirementLocations
  }
  set requirementLocations(value: LocationInput[]){
    this.requirementMaterial.requirementLocations = value
  }

  addSelectedMaterial(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    if(!value){
      return;
    }

    if (!this.selectedMaterials.find(x => x.value === value)) {
      this.selectedMaterials.push(new SelectOptionMaterial(value));
    }

    this.materialAutocompleteValue.set("");
    event.chipInput.clear();    
  }

  materialSelected(event: MatAutocompleteSelectedEvent){        
    event.option.deselect();               
    if (!this.selectedMaterials.find(x => x.value === event.option.value)) { 
      this.selectedMaterials.push(new SelectOptionMaterial(event.option.value, event.option.viewValue));    
    }
    this.materialAutocompleteValue.set("");
    setTimeout(() => {
      this.materialAutocompleteValue.set("");      
    }, 1000);
  }
  removeSelectedMaterial(selectedMaterial: SelectOptionMaterial){
    const index = this.selectedMaterials.indexOf(selectedMaterial);
    if(index < 0) return;
    this.selectedMaterials.splice(index, 1);
  }
  addRequirementTime(){
    this.requirementTimes.push(new ProjectTimeInput());
  }
  removeRequirementTime(requirementTime: ProjectTimeInput){
    const index = this.requirementTimes.indexOf(requirementTime);
    if(index < 0) return;
    this.requirementTimes.splice(index, 1);
  }
  addRequirementLocation(){
    this.requirementLocations.push(new LocationInput());
  }
  removeRequirementLocation(requirementLocation: LocationInput){
    const index = this.requirementLocations.indexOf(requirementLocation);
    if(index < 0) return;
    this.requirementLocations.splice(index, 1);
  }
}
