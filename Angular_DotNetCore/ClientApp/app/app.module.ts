import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from "./app.component";
import { ProductListComponent } from './product-list.component';
import { ProductDetailsComponent } from './product-detail.component';
import { ProductCreateComponent } from './product-create.component';
import { ProductEditComponent } from './product-edit.component';
import { NotFoundComponent } from './not-found.component';
import { DataService } from './data.service';
import { ProductFormComponent } from './product-form.component';

const appRoutes: Routes = [
    { path: '', component: ProductListComponent },
    { path: 'create', component: ProductCreateComponent },
    { path: 'edit/:id', component: ProductEditComponent },
    { path: 'product/:id', component: ProductDetailsComponent },
    { path: '**', component: NotFoundComponent }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, ProductListComponent, ProductCreateComponent, ProductEditComponent, ProductFormComponent, NotFoundComponent],
    providers: [DataService],
    bootstrap: [AppComponent]
})

export class AppModule {
    
}