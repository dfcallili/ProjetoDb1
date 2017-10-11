import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Headers, RequestOptions, BaseRequestOptions } from '@angular/http';
import { APP_BASE_HREF, CommonModule, Location, LocationStrategy, HashLocationStrategy } from '@angular/common';
// third party module to display toast 
import { ToastrModule } from 'toastr-ng2';
//PRIMENG - Third party module
import { InputTextModule, DataTableModule, ButtonModule, DialogModule } from 'primeng/primeng';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { CandidatoComponent } from './components/candidato/candidato.component';
import { TecnologiaComponent } from './components/tecnologia/tecnologia.component';
import { VagaComponent } from './components/vaga/vaga.component';
import { EntrevistaComponent } from './components/entrevista/entrevista.component';

import { CandidatoService, TecnologiaService, VagaService, EntrevistaService } from './_services/index';

class AppBaseRequestOptions extends BaseRequestOptions {
    headers: Headers = new Headers();
    constructor() {
        super();
        this.headers.append('Content-Type', 'application/json');
        this.body = '';
    }
}

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CandidatoComponent,
        TecnologiaComponent,
        VagaComponent,
        EntrevistaComponent
    ],
    providers: [CandidatoService, TecnologiaService, VagaService, EntrevistaService,
        { provide: LocationStrategy, useClass: HashLocationStrategy },
        { provide: RequestOptions, useClass: AppBaseRequestOptions }],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        BrowserAnimationsModule,
        ToastrModule.forRoot(),
        InputTextModule, DataTableModule, ButtonModule, DialogModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'candidato', component: CandidatoComponent },
            { path: 'tecnologia', component: TecnologiaComponent },
            { path: 'vaga', component: VagaComponent },
            { path: 'entrevista', component: EntrevistaComponent },
            
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
