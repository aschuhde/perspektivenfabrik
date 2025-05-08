import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogTitle } from '@angular/material/dialog';
import { MatIcon } from '@angular/material/icon';
import { TranslateModule, TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-save-project-error-dialog',
  imports: [MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, MatButtonModule, TranslateModule, MatIcon],
  templateUrl: './save-project-error-dialog.component.html',
  styleUrl: './save-project-error-dialog.component.scss'
})
export class SaveProjectErrorDialogComponent {
  data = inject(MAT_DIALOG_DATA);
  title: string = this.data?.title ?? "";
  titleEncoded: string = this.data?.titleEncoded ?? "";
  message: string = this.data?.message ?? "";
  messageToAdd: string = this.data?.messageToAdd ?? "";
  withPersonalData: boolean = this.data?.withPersonalData ?? false;
  savingFailedMessage: string = this.data?.savingFailedMessage ?? "";
  translateService = inject(TranslateService);
  
  clipboardIsCopied = false;
  copyToClipboard() {
    navigator.clipboard.write([new ClipboardItem({
      'text/html': new Blob([this.messageToAdd], { type: 'text/html' }),
      'text/plain': new Blob([this.messageToAdd], { type: 'text/plain' })
    })]).then(r => {
      this.clipboardIsCopied = true;
      setTimeout(() => {
        this.clipboardIsCopied = false;
      }, 5000);
    });
  }
  
  get mainMessage(){
    return this.savingFailedMessage + this.translateService.instant("saveProjectErrorDialog.whatToDo", {titleEncoded: this.titleEncoded});
  }
}
