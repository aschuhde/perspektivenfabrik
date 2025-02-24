import { Component, model } from '@angular/core';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule} from '@angular/forms';
import { provideLuxonDateAdapter } from '@angular/material-luxon-adapter';
import {DateRange, MatDatepickerModule} from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { DateTime } from 'luxon';
import {provideNativeDateAdapter} from "@angular/material/core";

export const DATE_FORMAT_DATE = {
  parse: {
    dateInput: 'dd.MM.yyyy',
  },
  display: {
    dateInput: 'dd.MM.yyyy',
    monthYearLabel: 'dd.MM.yyyy',
    dateA11yLabel: 'dd.MM.yyyy',
    monthYearA11yLabel: 'dd.MM.yyyy',
  },
};

@Component({
  selector: 'app-date-picker-range',
  imports: [MatFormFieldModule, MatDatepickerModule, FormsModule, ReactiveFormsModule],
  templateUrl: './date-picker-range.component.html',
  styleUrl: './date-picker-range.component.scss',
  providers: [provideLuxonDateAdapter(DATE_FORMAT_DATE)]
})
export class DatePickerRangeComponent {
  readonly startDate = model.required<DateTime | null>();
  readonly endDate = model.required<DateTime | null>();
  readonly range = new FormGroup({
    start: new FormControl<DateTime | null>(null),
    end: new FormControl<DateTime | null>(null),
  });

  ngOnInit() {
    this.range.controls.start.setValue(this.startDate());
    this.range.controls.end.setValue(this.endDate());
  }
  
  changed(){
    this.startDate.set(this.range.value.start ?? null);
    this.endDate.set(this.range.value.end ?? null);
  }
}
