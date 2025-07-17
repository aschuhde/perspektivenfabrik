import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogTitle } from '@angular/material/dialog';
import { MatIcon } from '@angular/material/icon';
import {MatFormField, MatInput } from '@angular/material/input';
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'app-reject-project-dialog',
  imports: [MatDialogContent,
  MatDialogActions,
  MatDialogTitle,
  MatFormField,
      MatInput,
  FormsModule, 
      MatIcon,
      MatDialogClose,
    TranslatePipe],
  templateUrl: './reject-project-dialog.component.html',
  styleUrl: './reject-project-dialog.component.scss'
})
export class RejectProjectDialogComponent {
  reason: string = "";
  data = inject(MAT_DIALOG_DATA);


  submit() {
    if(!this.reason){
      return;
    }
    this.data.onSubmit(this.reason);
  }
}
