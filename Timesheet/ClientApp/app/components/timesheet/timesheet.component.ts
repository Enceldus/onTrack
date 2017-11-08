import { Component, OnInit} from '@angular/core';
import { NgModule } from '@angular/core';
//import { SharedService } from '../shared/shared.service';
import { TimesheetDetail } from '../shared/timesheet-detail.type';
import { DayTask } from '../shared/timesheet-DayTask';
//import { TimesheetService } from '../shared/timesheet.service';
import { ActivatedRoute } from '@angular/router';


@Component({
	selector: 'time-sheet',
	templateUrl:'./timesheet.component.html'
})

export class TimesheetComponent implements OnInit{	
    message: string= "I am Parent";
    timesheetDetail: TimesheetDetail;
   // _daytask: DayTask[];
    _daytask: Array<DayTask>;
		//private static Timesheet _timesheet:
  //  new Timesheet { Displydate: "Oct 15-21", Weekoftheyear: 43, DayTasks: _daytask };
    constructor() {
        //this._daytask= [{ Date :"15", DayName: "Sun", Project: "KPHC", EmpID: "DH", Dayhrs: 0, TimeSheetStatus: "D" },
        //    { Date: "16", DayName: "Mon", Project: "KPHC", EmpID: "DH", Dayhrs: 7, TimeSheetStatus: "D" },
        //     { Date: "17", DayName: "Tue", Project: "KPHC", EmpID: "DH", Dayhrs: 5, TimeSheetStatus: "D" },
        //    { Date: "18", DayName: "Wed", Project: "KPHC", EmpID: "DH", Dayhrs: 9, TimeSheetStatus: "D" },
        //    { Date: "19", DayName: "Thu", Project: "KPHC", EmpID: "DH", Dayhrs: 8, TimeSheetStatus: "D" },
        //    { Date: "20", DayName: "Fri", Project: "KPHC", EmpID: "DH", Dayhrs: 10, TimeSheetStatus: "D" },
        //    { Date: "21", DayName: "Sat", Project: "KPHC", EmpID: "DH", Dayhrs: 0, TimeSheetStatus: "D" }];

        //this.timesheetDetail = { Displydate: "Oct 15-21", Weekoftheyear: 43, DayTasks: this._daytask };
        //console.log("From Transferpage AAAAAbbbbbbbbbb");
    }

    ngOnInit()
    {
        this._daytask = [{ Date: "15", DayName: "Sun", Project: "KPHC", EmpID: "DH", Dayhrs: 0, TimeSheetStatus: "D", colOrder:1 },
            { Date: "16", DayName: "Mon", Project: "KPHC", EmpID: "DH", Dayhrs: 7, TimeSheetStatus: "D", colOrder: 2},
            { Date: "17", DayName: "Tue", Project: "KPHC", EmpID: "DH", Dayhrs: 5, TimeSheetStatus: "D", colOrder: 3 },
            { Date: "18", DayName: "Wed", Project: "KPHC", EmpID: "DH", Dayhrs: 9, TimeSheetStatus: "D", colOrder: 4 },
            { Date: "19", DayName: "Thu", Project: "KPHC", EmpID: "DH", Dayhrs: 8, TimeSheetStatus: "D", colOrder: 5 },
            { Date: "20", DayName: "Fri", Project: "KPHC", EmpID: "DH", Dayhrs: 10, TimeSheetStatus: "D", colOrder: 6},
            { Date: "21", DayName: "Sat", Project: "KPHC", EmpID: "DH", Dayhrs: 0, TimeSheetStatus: "D", colOrder: 7}];

        this.timesheetDetail = { Displydate: "Oct 15-21",EmpName: "Dhira S", Weekoftheyear: 43, DayTasks: this._daytask };
        console.log("From Transferpage AAAAAbbbbbbbbbb");

         //   this.timesheetDetail.Displydate= "Dhiraj43242342423";

        console.log("From Transferpage AAAAA88888");
    }
		
	
	
}
