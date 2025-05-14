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
import {AutocompleteDataService} from "../../../../shared/services/autocomplete-data.service";
import { TranslateModule } from '@ngx-translate/core';
import {
  MatInputTranslationsComponent
} from "../../../../shared/components/mat-input-translations/mat-input-translations.component";
import {TranslationValue} from "../../../../shared/models/translation-value";
import {LanguageService} from "../../../../core/services/language-service.service";

@Component({
  selector: 'app-edit-requirement-material',
  imports: [FormsModule, MatFormField, MatLabel, MatInput, MatIcon, MatOption, MatAutocompleteModule, MatChipsModule, MatSlideToggle, InputProjectTimeComponent, InputLocationComponent, MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, TranslateModule, MatInputTranslationsComponent],
  templateUrl: './edit-requirement-material.component.html',
  styleUrl: './edit-requirement-material.component.scss'
})
export class EditRequirementMaterialComponent { 
  data = inject(MAT_DIALOG_DATA);
  readonly dialog = inject(MatDialog);
  readonly addOnBlur = false;
  readonly separatorKeysCodes = [ENTER, COMMA, TAB] as const;
  requirementMaterial: RequirementMaterialInput = this.data?.requirementMaterial;
  autoCompleteDataService = inject(AutocompleteDataService);

  materialAutocompleteValue = model("");
  materialOptions: SelectOptionMaterial[] = [];
  requirementIndex: number = this.data?.requirementIndex;
    onChanged: () => void = this.data?.onChanged;
    languageService = inject(LanguageService);

  ngOnInit(){
    this.autoCompleteDataService.getMaterials().then(x => {
      this.materialOptions = x?.filter(y => !!y).map(y => {
        const valueTranslations = TranslationValue.arrayFromApiTranslationValues(y.nameTranslations ?? []);
        return new SelectOptionMaterial({
          value: TranslationValue.getTranslationIfExist(y.name ?? "", valueTranslations, this.languageService.currentLanguageCode),
          valueTranslations: valueTranslations
        });
      }) ?? [];
    })
  }
  
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
      this.onUpdated();
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
      this.onUpdated();
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
      const materialOption = this.materialOptions.find(x => x.value === value);
      this.selectedMaterials.push(new SelectOptionMaterial({
        value: value,
        text: value,
        valueTranslations: materialOption?.valueTranslations,
        textTranslations: materialOption?.textTranslations
      }));
        this.onUpdated();
    }

    this.materialAutocompleteValue.set("");
    event.chipInput.clear();    
  }

  materialSelected(event: MatAutocompleteSelectedEvent){        
    event.option.deselect();               
    if (!this.selectedMaterials.find(x => x.value === event.option.value)) {
      const materialOption = this.materialOptions.find(x => x.value === event.option.value);
      this.selectedMaterials.push(new SelectOptionMaterial({
        value: event.option.value,
        text: event.option.viewValue,
        valueTranslations: materialOption?.valueTranslations,
        textTranslations: materialOption?.textTranslations
      }));
        this.onUpdated();
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
