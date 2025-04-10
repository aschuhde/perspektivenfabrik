import {Component, inject, model} from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogTitle
} from "@angular/material/dialog";
import {MatFormField, MatInput, MatLabel} from "@angular/material/input";
import {FormsModule} from "@angular/forms";
import {MatIconModule} from "@angular/material/icon";

@Component({
  selector: 'app-share-link-dialog',
  imports: [
    MatDialogActions,
    MatDialogClose,
    MatDialogContent,
    MatDialogTitle,
    MatFormField,
    MatInput,
    MatLabel,
    MatFormField,
    FormsModule,
    MatIconModule
  ],
  templateUrl: './share-link-dialog.component.html',
  styleUrl: './share-link-dialog.component.scss'
})
export class ShareLinkDialogComponent {
  data = inject(MAT_DIALOG_DATA);
  readonly dialog = inject(MatDialog);
  link: string = this.data?.link;
  clipboardIsCopied = false;
  copyToClipboard() {
    navigator.clipboard.writeText(this.link).then(r => {
      this.clipboardIsCopied = true;
      setTimeout(() => {
        this.clipboardIsCopied = false;
      }, 5000);
    });
  }
  
  ngOnInit(){
    this.copyToClipboard();
  }
}
