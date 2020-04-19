import { Pipe, PipeTransform } from '@angular/core';
import { AdStatus } from '../../_enums/adStatus.enum';


@Pipe({
  name: 'adStatus'
})

export class AddStatusPipe implements PipeTransform {
  transform(value: AdStatus) {
    const val = value == null ? undefined : AdStatus[value];
    return val;
  }

}

