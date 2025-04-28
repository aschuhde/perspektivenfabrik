import { Component, inject, model, output } from '@angular/core';
import { ProjectTimeInput, ProjectTimeType } from '../../models/project-time-input';
import { MatDialog } from '@angular/material/dialog';
import { MessageDialogData } from '../../../../shared/models/message-dialog-data';
import { MessageDialogComponent } from '../../../../shared/dialogs/message-dialog/message-dialog.component';
import { MatIcon } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatOption, MatSelect } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { provideLuxonDateAdapter } from '@angular/material-luxon-adapter';
import { DateTime } from "luxon";
import { DatePickerComponent } from '../../../../shared/components/date-picker/date-picker.component';
import { MonthPickerComponent } from '../../../../shared/components/month-picker/month-picker.component';
import { DatePickerRangeComponent } from '../../../../shared/components/date-picker-range/date-picker-range.component';
import { TranslateModule } from '@ngx-translate/core';

export const DATE_FORMAT_MONTH = {
  parse: {
    dateInput: 'dd.MM.yyyy',
  },
  display: {
    dateInput: 'dd.MM.yyyy',
    monthYearLabel: 'MMMM yyyy',
    dateA11yLabel: 'dd.MM.yyyy',
    monthYearA11yLabel: 'MMMM yyyy',
  },
};

@Component({
  selector: 'app-input-project-time',
  imports: [MatFormFieldModule, MatInputModule, MatIcon, MatSelect, MatOption, DatePickerComponent, MonthPickerComponent, DatePickerRangeComponent, TranslateModule],
  templateUrl: './input-project-time.component.html',
  styleUrl: './input-project-time.component.scss',
  providers: [provideLuxonDateAdapter(DATE_FORMAT_MONTH)]
})
export class InputProjectTimeComponent {
  readonly dialog = inject(MatDialog);
  timeIndex = model.required<number>();
  projectTime = model.required<ProjectTimeInput>();
  remove = output<ProjectTimeInput>();
    onChanged = output();

  get timeNumber(){
    return this.timeIndex() + 1;
  }
  get typeName(){
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
      this.remove.emit(this.projectTimeObject);
    }  
  
    showMessageDialog(dialogData: MessageDialogData) {
      this.dialog.open(MessageDialogComponent, {
        data: dialogData
      });
    }
  
}
