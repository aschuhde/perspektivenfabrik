import { Component, inject, model, output } from '@angular/core';
import { ProjectTimeInput } from '../../models/project-time-input';
import { MatDialog } from '@angular/material/dialog';
import { MessageDialogData } from '../../../../shared/models/message-dialog-data';
import { MessageDialogComponent } from '../../../../shared/dialogs/message-dialog/message-dialog.component';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatOption, MatSelect } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { provideLuxonDateAdapter } from '@angular/material-luxon-adapter';
import { DateTime } from "luxon";
import { DatePickerComponent } from '../../../../shared/components/date-picker/date-picker.component';
import { MonthPickerComponent } from '../../../../shared/components/month-picker/month-picker.component';
import { DatePickerRangeComponent } from '../../../../shared/components/date-picker-range/date-picker-range.component';

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
  imports: [MatFormFieldModule, MatInputModule, MatIcon, MatSelect, MatOption, MatButton, DatePickerComponent, MonthPickerComponent, DatePickerRangeComponent],
  templateUrl: './input-project-time.component.html',
  styleUrl: './input-project-time.component.scss',
  providers: [provideLuxonDateAdapter(DATE_FORMAT_MONTH)]
})
export class InputProjectTimeComponent {
  readonly dialog = inject(MatDialog);

  projectTime = model.required<ProjectTimeInput>();
  remove = output<ProjectTimeInput>();
  projectTimeType : "unknown" | "range" | "date" | "month" = "unknown"
  startDate: DateTime | null = DateTime.now()
  endDate: DateTime | null = DateTime.now()
  month: DateTime | null = DateTime.now()
  date: DateTime | null = DateTime.now()

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
