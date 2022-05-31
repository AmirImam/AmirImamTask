import { ValidationErrors } from "@angular/forms";

export class ComponentBase {
    public Errors: Array<{ Key: string, Value: Array<string> }> = new Array<{ Key: string, Value: Array<string> }>();

    public AssignErrors(items?: { Key: string, Value: Array<string> }[]): void {

        if (items == null) {
            return;
        }
        for (let key in items) {
            let arr: any;//string[] = [];
            arr = items[key];// as string[];
            let item = { Key: key, Value: arr };
            this.Errors.push(item);
        }
    }

    public AssignError(key: string, value: string): void {
        this.Errors.push({ Key: key, Value: [value] });
    }

    public GetFormValidationErrors(form: HTMLFormElement) {
        // Object.keys(form.elements).forEach(key => {
        //     const controlErrors: ValidationErrors = form.get(key).errors;
        //     if (controlErrors != null) {
        //         Object.keys(controlErrors).forEach(keyError => {
        //             console.log('Key control: ' + key + ', keyError: ' + keyError + ', err value: ', controlErrors[keyError]);
        //         });
        //     }
        // });
    }
}