import { Component, model } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatDatepicker, MatDatepickerModule } from '@angular/material/datepicker';
import { DateTime } from "luxon";
import { TranslateModule } from '@ngx-translate/core';
import {provideLuxonDateAdapterMonth} from "../../tools/language-tools";

@Component({
  selector: 'app-month-picker',
  imports: [MatFormFieldModule, MatInputModule, MatDatepickerModule, FormsModule, TranslateModule],
  templateUrl: './month-picker.component.html',
  styleUrl: './month-picker.component.scss',
  providers: [provideLuxonDateAdapterMonth()]
})
export class MonthPickerComponent {
  readonly month = model.required<DateTime | null>();

  setMonthAndYear(monthAndYear: DateTime, datepicker: MatDatepicker<DateTime>) {
    this.month.set(monthAndYear);
    datepicker.close();
  }
}
