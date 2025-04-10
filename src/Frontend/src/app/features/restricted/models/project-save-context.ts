import {ProjectInput} from "./project-input";
import {ApplicationModelsApiModelsApiProjectBody} from "../../../server/model/applicationModelsApiModelsApiProjectBody";

export class ProjectSaveContext{
    isSaving : boolean = false;
    hasChanges: boolean = false;
    lastSave: Date | null = null;
    madeChangesWhileSaving: boolean = false;
    lastSavedProjectRequest: ApplicationModelsApiModelsApiProjectBody | null = null;
    onChange(projectInput: ProjectInput){
        if(this.hasChanges){
            return;
        }
        
        projectInput.buildRequest().then((x) => {
            if(JSON.stringify(this.lastSavedProjectRequest) === JSON.stringify(x)){
                return;
            }
            if(this.isSaving){
                this.madeChangesWhileSaving = true;
            }
            this.hasChanges = true; 
        });
    }
}