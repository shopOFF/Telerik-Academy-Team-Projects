import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'uploadedOn'
})
export class UploadedOnPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return 'Uploaded On: ' + value;
  }
}
