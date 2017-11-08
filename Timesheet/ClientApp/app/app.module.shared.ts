import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { TimesheetComponent } from './components/timesheet/timesheet.component';
import { ClientMasterComponent } from './components/clientmaster/clientmaster.component';
import { TaskMasterComponent } from './components/taskmaster/taskmaster.component';



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        TimesheetComponent,
        ClientMasterComponent,
        TaskMasterComponent,
        HomeComponent
        
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'time-sheet', component: TimesheetComponent },
            { path: 'client-master', component: ClientMasterComponent },
            { path: 'task-master', component: TaskMasterComponent },
            
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
