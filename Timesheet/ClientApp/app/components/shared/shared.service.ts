import { Injectable } from '@angular/core';

@Injectable()
export class SharedService {

	constructor() { }
	public getProjectTask(): any {	
		 var projectTask = { "Project1": "P1-T1", "Project2": "P1-T2", "Kaiser": "Kaiser-T1" };
		return projectTask;
	}
	public gethrs(): any {
		var hrs = { "1": 8, "2": 10, "3": 8, "4": 8, "5": 9, "7": 0, "8": 0   };
		return hrs;
	}

	//public createUser(user: UserModel): any {
	//	console.log(this.firebaseService)
	//	console.log(user);
	//	//     this.firebaseService.set(user)
	//}

	//public getUser(username: string): any {
	//	//     return this.firebaseService.get("users/" + username);
	//}
}