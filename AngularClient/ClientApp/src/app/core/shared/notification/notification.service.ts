import { Injectable, Injector, OnInit } from "@angular/core";
import { NavigationStart, Router } from "@angular/router";
import { Observable, Subject } from "rxjs";
//import swal from 'sweetalert2'

@Injectable()
export class NotificationService {

	private subject = new Subject<Notification>();
    private keepAfterNavigationChange = false;
    private _router: Router;

    constructor(private injector: Injector) {
        this._router = this.injector.get(Router);
        this._router.events.subscribe(event => {
            if (event instanceof NavigationStart) {
                if (this.keepAfterNavigationChange) {
                    // only keep for a single location change
                    this.keepAfterNavigationChange = false;
                } else {
                    // clear Notification
                    this.clear();
                }
            }
        });
    }






    getMessage(): Observable<any> {
        return this.getNotification();
    }

    getNotification(): Observable<any> {
        return this.subject.asObservable();
    }


    success(message: string, title: string = '', keepAfterNavigationChange = false) {
        this.Notification(NotificationType.Success, message, title, keepAfterNavigationChange);
    }

    error(message: string, title: string = '', keepAfterNavigationChange = false) {
        //console.log('calling Notification(), type: '+NotificationType.Error + ' message: '+message);
        this.Notification(NotificationType.Error, message, title, keepAfterNavigationChange);

    }

    info(message: string, title: string = '', keepAfterNavigationChange = false) {
        this.Notification(NotificationType.Info, message, title, keepAfterNavigationChange);
    }

    warn(message: string, title: string = '', keepAfterNavigationChange = false) {
        this.Notification(NotificationType.Warning, message, title, keepAfterNavigationChange);
    }


    primary(message: string, title: string = '', keepAfterNavigationChange = false) {
        this.Notification(NotificationType.Primary, message, title, keepAfterNavigationChange);
    }

    brand(message: string, title: string = '', keepAfterNavigationChange = false) {
        this.Notification(NotificationType.Brand, message, title, keepAfterNavigationChange);
    }

	Notification(type: NotificationType, message: string, title: string = '', keepAfterNavigationChange = false) {
		if (this.subject) {
			this.keepAfterNavigationChange = keepAfterNavigationChange;
			this.subject.next(<Notification>{ type: type, message: message, title: title });
		}

        //console.log('Notification pushed');
    }



    clear() {
        // clear Notifications
		if (this.subject) {
			this.subject.next();
		}
     
    }

}


export class Notification {
    type: NotificationType;
    message: string;
    notifyElement: any;
    title: string;
}

export enum NotificationType {
    Success,
    Error,
    Info,
    Warning,
    Brand,
    Primary
}
