import { CoreExternalDependenciesModule } from './core/core-external-dependencies.module';
import { GalleryModule } from './modules/gallery/gallery.module';
import { UserAdministrationModule } from './modules/user-administration/user-administration.module';
import { HomeModule } from './modules/home/home.module';
import { SharedModule } from './modules/shared/shared.module';
import { CoreModule } from './core/core.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    CoreModule,
    CoreExternalDependenciesModule,
    SharedModule,
    HomeModule,
    GalleryModule,
    UserAdministrationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
