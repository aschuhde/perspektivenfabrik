import { Component, model } from '@angular/core';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule} from '@angular/forms';
import { MatDatepickerModule} from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { DateTime } from 'luxon';
import { TranslateModule } from '@ngx-translate/core';
import { provideLuxonDateAdapterFullDate } from '../../tools/language-tools';


@Component({
  selector: 'app-date-picker-range',
  imports: [MatFormFieldModule, MatDatepickerModule, FormsModule, ReactiveFormsModule, TranslateModule],
  templateUrl: './date-picker-range.component.html',
  styleUrl: './date-picker-range.component.scss',
  providers: [provideLuxonDateAdapterFullDate()]
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
