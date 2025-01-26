import { Component, inject, model, output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatOption, MatSelect } from '@angular/material/select';
import { MatInput } from '@angular/material/input';
import { RequirementPersonInput } from '../../models/requirement-person-input';
import { MessageDialogData } from '../../../../shared/models/message-dialog-data';
import { MessageDialogComponent } from '../../../../shared/dialogs/message-dialog/message-dialog.component';
import { SelectOption } from '../../../../shared/models/select-option';
import { MatAutocompleteModule, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { FormsModule } from '@angular/forms';
import { MatChipInputEvent, MatChipsModule } from '@angular/material/chips';
import { COMMA, ENTER, TAB } from '@angular/cdk/keycodes';
import { MatSlideToggle } from '@angular/material/slide-toggle';
import { ProjectTimeInput } from '../../models/project-time-input';
import { InputProjectTimeComponent } from '../input-project-time/input-project-time.component';
import { LocationInput } from '../../models/location-input';
import { InputLocationComponent } from '../input-location/input-location.component';

@Component({
  selector: 'app-input-requirement-person',
  imports: [FormsModule, MatFormField, MatLabel, MatInput, MatIcon, MatSelect, MatOption, MatButton, MatAutocompleteModule, MatChipsModule, MatSlideToggle, InputProjectTimeComponent, InputLocationComponent],
  templateUrl: './input-requirement-person.component.html',
  styleUrl: './input-requirement-person.component.scss'
})
export class InputRequirementPersonComponent {
  readonly dialog = inject(MatDialog);
  readonly addOnBlur = false;
  readonly separatorKeysCodes = [ENTER, COMMA, TAB] as const;
  requirementPerson = model.required<RequirementPersonInput>();
  remove = output<RequirementPersonInput>();
  skillAutocompleteValue = model("");
  skillOptions: SelectOption[] = [new SelectOption("Designer*in"), new SelectOption("Softwareentwickler*in"), new SelectOption("Projektorganisator*in")];
  selectedSkills: SelectOption[] = [];  
  numberOfPersons: string = "1";
  effortHoursType: "perWeek" | "total" = "perWeek";
  hours: string = "";
  requirementTimeIsIdenticalToProjectTime: boolean = true
  requirementTimes: ProjectTimeInput[] = [new ProjectTimeInput()];
  requirementLocationIsIdenticalToProjectLocation: boolean = true
  requirementLocations: LocationInput[] = [new LocationInput()];

  readonly messageDialogs = {
  
  };
  removeClicked(){
    this.remove.emit(this.requirementPerson());
  }  

  showMessageDialog(dialogData: MessageDialogData) {
    this.dialog.open(MessageDialogComponent, {
      data: dialogData
    });
  }
  addSelectedSkill(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    if(!value){
      return;
    }

    if (!this.selectedSkills.find(x => x.value === value)) {
      this.selectedSkills.push(new SelectOption(value));
    }

    this.skillAutocompleteValue.set("");
    event.chipInput.clear();    
  }

  skillSelected(event: MatAutocompleteSelectedEvent){        
    event.option.deselect();               
    if (!this.selectedSkills.find(x => x.value === event.option.value)) { 
      this.selectedSkills.push(new SelectOption(event.option.value, event.option.viewValue));    
    }
    this.skillAutocompleteValue.set("");
    setTimeout(() => {
      this.skillAutocompleteValue.set("");      
    }, 1000);
  }
  removeSelectedSkill(selectedSkill: SelectOption){
    const index = this.selectedSkills.indexOf(selectedSkill);
    if(index < 0) return;
    this.selectedSkills.splice(index, 1);
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
