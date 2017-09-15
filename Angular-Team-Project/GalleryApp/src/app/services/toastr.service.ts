import { ToastsManager } from 'ng2-toastr/src/toast-manager';
import { Injectable, ViewContainerRef, Host } from '@angular/core';

@Injectable()
export class ToastrService {

    private vcr: ViewContainerRef;
    /**
     * Creates an instance of ToastrService. AND USE THE initToasterService() METHOD !!!
     * @param {ToastsManager} toastr
     * @memberof ToastrService
     */
    constructor(public toastr: ToastsManager) {
    }
    /**
     * Give ViewContainerRef dependency from your component that uses the service to the initToasterService method
     * so the Toaster can be initialized and you can use it!!!
     * @param {ViewContainerRef} viewContainerRef
     * @memberof ToastrService
     */
    initToasterService(viewContainerRef: ViewContainerRef) {
        this.vcr = viewContainerRef;
        this.toastr.setRootViewContainerRef(this.vcr);
    }
    getSuccessMessage(message: string) {
        this.toastr.success(message);
    }
    getErrorMessage(message: string) {
        this.toastr.error(message);
    }

    clearAllToasts() {
        this.toastr.clearAllToasts();
    }
}
