import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from "./app.component";
import { NotFoundComponent } from './components/not-found-component/not-found.component';
import { AirPathComponent } from './components/air-path/air-path.component';
import { DataService } from './services/data.service';
/**Routes. */
const appRoutes: Routes = [
    { path: '', component: AirPathComponent },
    { path: '**', component: NotFoundComponent }
];

/**App Module. */
@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [
        AppComponent,
        AirPathComponent,
        NotFoundComponent,
    ],
    providers: [DataService],
    bootstrap: [AppComponent]
})
export class AppModule {
}