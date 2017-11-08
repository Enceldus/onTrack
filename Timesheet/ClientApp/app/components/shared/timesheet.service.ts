import { Injectable, Inject} from '@angular/core';
//import { Component } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/filter';
import { TimesheetDetail } from './timesheet-detail.type';
import { DayTask } from './timesheet-daytask';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class TimesheetService {
	handleError: any;
	timesheetDetail: TimesheetDetail;
	constructor(private http: Http) {

	}

	//getTimesheetByWeek() {
	//	//return this._http.get('http://localhost:21855/api/Timesheet/GetTimesheetByWeek')
	//	//	.map((res: Response) => res.json())
	//	//	.subscribe(data => {
	//	//		this.timesheetDetail = data;
	//	//		console.log(this.timesheetDetail);
	//	//	});
	//	//	//.map(response => response.json() as TimesheetDetail).;


	//	return this._http.get('http://localhost:21855/api/Timesheet/GetTimesheetByWeek')
	//		//.map(res => <TimesheetDetail>res.json())
	//		.subscribe(data => { this.timesheetDetail = data as TimesheetDetail});
	//		//.catch(this.handleError);
	//}


	getTimesheetByWeek(): Observable<any> {
		return this.http.get('http://localhost:21855/api/Timesheet/GetTimesheetByWeek')
			.map(response => response.json());
			//.catch(this.handleError);
	}

	
}