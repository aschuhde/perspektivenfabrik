import { ENTER, COMMA, TAB } from '@angular/cdk/keycodes';
import { Component, inject, model } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatAutocompleteModule, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatButton } from '@angular/material/button';
import { MatChipsModule, MatChipInputEvent } from '@angular/material/chips';
import { MatOption } from '@angular/material/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogTitle } from '@angular/material/dialog';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatIcon } from '@angular/material/icon';
import { MatInput } from '@angular/material/input';
import { MatSelect } from '@angular/material/select';
import { MatSlideToggle } from '@angular/material/slide-toggle';
import { MessageDialogComponent } from '../../../../shared/dialogs/message-dialog/message-dialog.component';
import { MessageDialogData } from '../../../../shared/models/message-dialog-data';
import { SelectOption } from '../../../../shared/models/select-option';
import { InputLocationComponent } from '../../components/input-location/input-location.component';
import { InputProjectTimeComponent } from '../../components/input-project-time/input-project-time.component';
import { LocationInput } from '../../models/location-input';
import { ProjectTimeInput } from '../../models/project-time-input';
import { RequirementPersonInput, EffortHoursType } from '../../models/requirement-person-input';
import { MapComponent } from '../../../../shared/components/map/map.component';

@Component({
  selector: 'app-edit-requirement-person',
  imports: [FormsModule, MatFormField, MatLabel, MatInput, MatIcon, MatSelect, MatOption, MatButton, MatAutocompleteModule, MatChipsModule, MatSlideToggle, InputProjectTimeComponent, InputLocationComponent, MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, MapComponent],
  templateUrl: './edit-requirement-person.component.html',
  styleUrl: './edit-requirement-person.component.scss'
})
export class EditRequirementPersonComponent {
  data = inject(MAT_DIALOG_DATA);
  readonly dialog = inject(MatDialog);
  readonly addOnBlur = false;
  readonly separatorKeysCodes = [ENTER, COMMA, TAB] as const;
  requirementPerson: RequirementPersonInput = this.data?.requirementPerson;
  
  skillAutocompleteValue = model("");
  skillOptions: SelectOption[] = [new SelectOption("Designer*in"), new SelectOption("Softwareentwickler*in"), new SelectOption("Projektorganisator*in")];
  requirementIndex: number = this.data?.requirementIndex;

  get requirementNumber(){
    return this.requirementIndex + 1;
  }

  get selectedSkills(){
    return this.requirementPerson.selectedSkills
  }
  set selectedSkills(value: SelectOption[]){
    this.requirementPerson.selectedSkills = value
  }
  
  get numberOfPersons(){
    return this.requirementPerson.numberOfPersons
  }
  set numberOfPersons(value: string){
    this.requirementPerson.numberOfPersons = value
  }

  get effortHoursType(){
    return this.requirementPerson.effortHoursType
  }
  set effortHoursType(value: EffortHoursType){
    this.requirementPerson.effortHoursType = value
  }
  get hours(){
    return this.requirementPerson.hours
  }
  set hours(value: string){
    this.requirementPerson.hours = value
  }
  get requirementTimeIsIdenticalToProjectTime(){
    return this.requirementPerson.requirementTimeIsIdenticalToProjectTime
  }
  set requirementTimeIsIdenticalToProjectTime(value: boolean){
    this.requirementPerson.requirementTimeIsIdenticalToProjectTime = value
  }
  get requirementTimes(){
    return this.requirementPerson.requirementTimes
  }
  set requirementTimes(value: ProjectTimeInput[]){
    this.requirementPerson.requirementTimes = value
  }
  get requirementLocationIsIdenticalToProjectLocation(){
    return this.requirementPerson.requirementLocationIsIdenticalToProjectLocation
  }
  set requirementLocationIsIdenticalToProjectLocation(value: boolean){
    this.requirementPerson.requirementLocationIsIdenticalToProjectLocation = value
  }
  get requirementLocations(){
    return this.requirementPerson.requirementLocations
  }
  set requirementLocations(value: LocationInput[]){
    this.requirementPerson.requirementLocations = value
  }

  readonly messageDialogs = {
  
  };

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
