import { ENTER, COMMA, TAB } from '@angular/cdk/keycodes';
import { Component, inject, model, output } from '@angular/core';
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
import {AutocompleteDataService} from "../../../../shared/services/autocomplete-data.service";

@Component({
  selector: 'app-edit-requirement-person',
  imports: [FormsModule, MatFormField, MatLabel, MatInput, MatIcon, MatSelect, MatOption, MatAutocompleteModule, MatChipsModule, MatSlideToggle, InputProjectTimeComponent, InputLocationComponent, MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose],
  templateUrl: './edit-requirement-person.component.html',
  styleUrl: './edit-requirement-person.component.scss'
})
export class EditRequirementPersonComponent {
  data = inject(MAT_DIALOG_DATA);
  readonly dialog = inject(MatDialog);
  readonly addOnBlur = false;
  readonly separatorKeysCodes = [ENTER, COMMA, TAB] as const;
  requirementPerson: RequirementPersonInput = this.data?.requirementPerson;
  autoCompleteDataService = inject(AutocompleteDataService);
  
  skillAutocompleteValue = model("");
  skillOptions: SelectOption[] = [];
  requirementIndex: number = this.data?.requirementIndex;
  onChanged: () => void = this.data?.onChanged;

  ngOnInit(){
    this.autoCompleteDataService.getSkills().then(x => {
      this.skillOptions = x?.filter(y => !!y).map(y => new SelectOption(y.name ?? "")) ?? [];
    })  
  }
  
  get requirementNumber(){
    return this.requirementIndex + 1;
  }

  get selectedSkills(){
    return this.requirementPerson.selectedSkills
  }
  set selectedSkills(value: SelectOption[]){
    this.requirementPerson.selectedSkills = value
      this.onUpdated();
  }
  
  get numberOfPersons(){
    return this.requirementPerson.numberOfPersons
  }
  set numberOfPersons(value: string){
    this.requirementPerson.numberOfPersons = value
      this.onUpdated();
  }

  get effortHoursType(){
    return this.requirementPerson.effortHoursType
  }
  set effortHoursType(value: EffortHoursType){
    this.requirementPerson.effortHoursType = value
      this.onUpdated();
  }
  get hours(){
    return this.requirementPerson.hours
  }
  set hours(value: string){
    this.requirementPerson.hours = value
      this.onUpdated();
  }
  get requirementTimeIsIdenticalToProjectTime(){
    return this.requirementPerson.requirementTimeIsIdenticalToProjectTime
  }
  set requirementTimeIsIdenticalToProjectTime(value: boolean){
    this.requirementPerson.requirementTimeIsIdenticalToProjectTime = value
      this.onUpdated();
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
      this.onUpdated();
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
        this.onUpdated();
    }

    this.skillAutocompleteValue.set("");
    event.chipInput.clear();    
  }

  skillSelected(event: MatAutocompleteSelectedEvent){        
    event.option.deselect();               
    if (!this.selectedSkills.find(x => x.value === event.option.value)) { 
      this.selectedSkills.push(new SelectOption(event.option.value, event.option.viewValue));
        this.onUpdated();
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
      this.onUpdated();
  }
  addRequirementTime(){
    this.requirementTimes.push(new ProjectTimeInput());
      this.onUpdated();
  }
  removeRequirementTime(requirementTime: ProjectTimeInput){
    const index = this.requirementTimes.indexOf(requirementTime);
    if(index < 0) return;
    this.requirementTimes.splice(index, 1);
      this.onUpdated();
  }
  addRequirementLocation(){
    this.requirementLocations.push(new LocationInput());
      this.onUpdated();
  }
  removeRequirementLocation(requirementLocation: LocationInput){
    const index = this.requirementLocations.indexOf(requirementLocation);
    if(index < 0) return;
    this.requirementLocations.splice(index, 1);
      this.onUpdated();
  }

    onUpdated() {
        this.onChanged();
    }
}
