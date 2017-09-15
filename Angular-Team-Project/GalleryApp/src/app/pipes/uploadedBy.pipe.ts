import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'uploadedBy'
})
export class UploadedByPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return 'Uploaded By: ' + value;
  }

}
