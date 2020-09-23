import { NgModule } from '@angular/core';
import { BootstrapIconsModule } from 'ng-bootstrap-icons';
import { Trash, PlusCircle, Pencil } from 'ng-bootstrap-icons/icons';

const icons = {
  Trash,
  PlusCircle,
  Pencil,
};

@NgModule({
  imports: [
    BootstrapIconsModule.pick(icons)
  ],
  exports: [
    BootstrapIconsModule
  ]
})
export class IconsModule { }
