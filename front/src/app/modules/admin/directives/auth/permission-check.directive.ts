import { Directive, ElementRef, Input } from "@angular/core";
import { AuthService } from '../../../../services/auth/auth.service';


@Directive({
    selector: '[permissionCheck]'
})
export class PermissionMenuCheckDirective {
    @Input('permissionCheck') role: string;

    constructor(private el: ElementRef,
        private authService: AuthService
        ) { }

    ngOnInit(): void {
        this.checkMenuItem();
    }

    checkMenuItem() {
        if(this.authService.getLoginProfile() === 'sa') return;

        this.authService.getRolesPermissions().subscribe(roles => {
            if (this.role && roles.indexOf(this.role) < 0) {
                this.el.nativeElement.remove();
            }
        });
    }
}