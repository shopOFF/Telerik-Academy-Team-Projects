import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'imageDetailTitle'
})
export class ImageDetailTitlePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return 'Image Details Page';
  }
}
