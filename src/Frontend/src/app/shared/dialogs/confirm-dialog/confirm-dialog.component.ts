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
  selector: 'app-confirm-dialog',
  imports: [MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, MatButtonModule],
  templateUrl: './confirm-dialog.component.html',
  styleUrl: './confirm-dialog.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ConfirmDialogComponent {
  data = inject(MAT_DIALOG_DATA);
  title: string = this.data?.title ?? "";
  message: string = this.data?.message ?? "";
  confirmButtonText: string = this.data?.confirmButtonText ?? "";
  cancelButtonText: string = this.data?.cancelButtonText ?? "";
  onConfirm: (dialog: ConfirmDialogComponent) => void = this.data?.onConfirm ?? (() => {});
  
  confirmDialog() {
    this.onConfirm(this);
  }
  
  closeDialog() {
   //todo 
  }
}
