import { TranslateService } from "@ngx-translate/core";
import { MatDialog } from "@angular/material/dialog";
import {ApplicationModelsApiModelsApiProjectBody} from "../../../server/model/applicationModelsApiModelsApiProjectBody";
import {escapeHtml} from "../../../shared/tools/formatting";
import {
    SaveProjectErrorDialogComponent
} from "../dialogs/save-project-error-dialog/save-project-error-dialog.component";

export function handleProjectSaveErrorAndGetDialogData(err: any, dialog: MatDialog, translateService: TranslateService, request: ApplicationModelsApiModelsApiProjectBody, contextName: string): never{
    const errorId = err?.error?.error?.errorId ?? "unknown";
    const errorMessage = err?.error?.error?.message?.content ?? "unknown";
    const titleEncoded = encodeURIComponent(`Bug Report - ${contextName} - ${errorId}`);
    const bodyEncoded = `Bug Report - ${contextName} - ${errorId}<br><br>Error:<br>${JSON.stringify(err?.error)}<br><br>Your personal server request:<br><strong>IMPORTANT: Remove the following data, if you do not want to share your server request with us!</strong><br><br>${escapeHtml(JSON.stringify(request))}`;
    
    if(err.status === 400) {
        dialog.open(SaveProjectErrorDialogComponent, {
            data: {
                title: translateService.instant("saveProjectErrorDialog.projectValidationFailedTitle"),
                messageToAdd: bodyEncoded,
                titleEncoded: titleEncoded,
                withPersonalData: false,
                savingFailedMessage: translateService.instant("saveProjectErrorDialog.projectValidationFailedMessage", {
                    errorMessage: errorMessage
                })
            }
        });
    }else{
        dialog.open(SaveProjectErrorDialogComponent, {
            data: {
                title: translateService.instant("saveProjectErrorDialog.projectFailedTitle"),
                messageToAdd: bodyEncoded,
                titleEncoded: titleEncoded,
                withPersonalData: true,
                savingFailedMessage: translateService.instant("saveProjectErrorDialog.projectFailedMessage")
            }
        });
    }
    throw err
}