import { Component, inject, model, output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatOption, MatSelect } from '@angular/material/select';
import { MatInput } from '@angular/material/input';
import { MessageDialogData } from '../../../../shared/models/message-dialog-data';
import { MessageDialogComponent } from '../../../../shared/dialogs/message-dialog/message-dialog.component';
import { MatAutocompleteModule, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { FormsModule } from '@angular/forms';
import { MatChipInputEvent, MatChipsModule } from '@angular/material/chips';
import { COMMA, ENTER, TAB } from '@angular/cdk/keycodes';
import { MatSlideToggle } from '@angular/material/slide-toggle';
import { ProjectTimeInput } from '../../models/project-time-input';
import { InputProjectTimeComponent } from '../input-project-time/input-project-time.component';
import { LocationInput } from '../../models/location-input';
import { InputLocationComponent } from '../input-location/input-location.component';
import { RequirementMaterialInput } from '../../models/requirement-material-input';
import { SelectOptionMaterial } from '../../../../shared/models/select-option-material';

@Component({
  selector: 'app-input-requirement-material',
  imports: [FormsModule, MatFormField, MatLabel, MatInput, MatIcon, MatSelect, MatOption, MatButton, MatAutocompleteModule, MatChipsModule, MatSlideToggle, InputProjectTimeComponent, InputLocationComponent],
  templateUrl: './input-requirement-material.component.html',
  styleUrl: './input-requirement-material.component.scss'
})
export class InputRequirementMaterialComponent {
  readonly dialog = inject(MatDialog);
  readonly addOnBlur = false;
  readonly separatorKeysCodes = [ENTER, COMMA, TAB] as const;
  requirementMaterial = model.required<RequirementMaterialInput>();
  remove = output<RequirementMaterialInput>();
  materialAutocompleteValue = model("");
  materialOptions: SelectOptionMaterial[] = [new SelectOptionMaterial("Holz"), new SelectOptionMaterial(""), new SelectOptionMaterial("Projektorganisator*in")];
  selectedMaterials: SelectOptionMaterial[] = [];  

  requirementTimeIsIdenticalToProjectTime: boolean = true
  requirementTimes: ProjectTimeInput[] = [new ProjectTimeInput()];
  requirementLocationIsIdenticalToProjectLocation: boolean = true
  requirementLocations: LocationInput[] = [new LocationInput()];

  

  readonly messageDialogs = {

  };
  removeClicked(){
    this.remove.emit(this.requirementMaterial());
  }  

  showMessageDialog(dialogData: MessageDialogData) {
    this.dialog.open(MessageDialogComponent, {
      data: dialogData
    });
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
