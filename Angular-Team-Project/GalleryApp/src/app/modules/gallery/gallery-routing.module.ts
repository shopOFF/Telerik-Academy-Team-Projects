import { UploadComponent } from './upload/upload.component';
import { AuthGuard } from './../../services/guards/auth-guard.service';
import { ImageDetailComponent } from './image-detail/image-detail.component';
import { GalleryComponent } from './gallery/gallery.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: GalleryComponent },
  { path: 'image/:id', component: ImageDetailComponent },
  { path: 'upload', component: UploadComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GalleryRoutingModule { }
