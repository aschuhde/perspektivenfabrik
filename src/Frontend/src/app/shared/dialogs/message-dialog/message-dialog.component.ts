import {ChangeDetectionStrategy, Component, inject} from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogTitle,
} from '@angular/material/dialog';

@Component({
  selector: 'app-message-dialog',
  imports: [MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, MatButtonModule],
  templateUrl: './message-dialog.component.html',
  styleUrl: './message-dialog.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MessageDialogComponent {
  data = inject(MAT_DIALOG_DATA);
  title: string = this.data?.title ?? "";
  message: string = this.data?.message ?? "";
  buttonText: string = this.data?.buttonText ?? "";
}
