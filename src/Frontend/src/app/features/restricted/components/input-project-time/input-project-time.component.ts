import { Component, inject, model, output } from '@angular/core';
import { ProjectTimeInput, ProjectTimeType } from '../../models/project-time-input';
import { MatDialog } from '@angular/material/dialog';
import { MatIcon } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatOption, MatSelect } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { DateTime } from "luxon";
import { DatePickerComponent } from '../../../../shared/components/date-picker/date-picker.component';
import { MonthPickerComponent } from '../../../../shared/components/month-picker/month-picker.component';
import { DatePickerRangeComponent } from '../../../../shared/components/date-picker-range/date-picker-range.component';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import {Language} from "../../../../core/types/general-types";


@Component({
  selector: 'app-input-project-time',
  imports: [MatFormFieldModule, MatInputModule, MatIcon, MatSelect, MatOption, DatePickerComponent, MonthPickerComponent, DatePickerRangeComponent, TranslateModule],
  templateUrl: './input-project-time.component.html',
  styleUrl: './input-project-time.component.scss',
  providers: []
})
export class InputProjectTimeComponent {
  readonly dialog = inject(MatDialog);
  timeIndex = model.required<number>();
  projectTime = model.required<ProjectTimeInput>();
  remove = output<ProjectTimeInput>();
    onChanged = output();
  translateService = inject(TranslateService)
  
  get timeNumber(){
    return this.timeIndex() + 1;
  }
  get currentLanguage(){
    return this.translateService.currentLang as Language;
  }
  get typeName(){
    if(this.currentLanguage === "it") {
      if (this.projectTimeType === "range") {
        return "Periodo";
      }
      if (this.projectTimeType === "month") {
        return "Mese";
      }
      return "Giorno";
    }
    
    if(this.projectTimeType === "range"){
      return "Zeitraum";
    }
    return "Zeitpunkt";
  }
  get date(){
    return this.projectTime().date
  }
  set date(value: DateTime | null){
    this.projectTime().date = value
      this.onChanged.emit();
  }
  get month(){
    return this.projectTime().month
  }
  set month(value: DateTime | null){
    this.projectTime().month = value
      this.onChanged.emit();
  }
  get startDate(){
    return this.projectTime().startDate
  }
  set startDate(value: DateTime | null){
    this.projectTime().startDate = value
      this.onChanged.emit();
  }
  get endDate(){
    return this.projectTime().endDate
  }
  set endDate(value: DateTime | null){
    this.projectTime().endDate = value
      this.onChanged.emit();
  }
  get projectTimeType(){
    return this.projectTime().projectTimeType
  }
  set projectTimeType(value: ProjectTimeType){
    this.projectTime().projectTimeType = value
      this.onChanged.emit();
  }

  get projectTimeObject(){
    return this.projectTime();
  }
  
    removeClicked(){
      this.remove.emit(this.projectTimeObject);
    }
  
}
