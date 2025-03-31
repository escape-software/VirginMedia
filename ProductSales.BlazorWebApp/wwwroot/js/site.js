//-------------------------------------------------------------------------------------------------
// Name        : Site
// Type        : Javascript
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used,
//               copied or modified without the express permission of the company in
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------

/*
 * Displays a status message in status panel and toggles the visibility of the status panel.
 *
 * @param {any} elementName1 - statusPanel element name
 * @param {any} elementName2 - statusMessage element name
 * @param {any} displayFlag - display status panel or not
 * @param {any} statusMessage - status message to display
*/
function displayImportStatus(elementName1, elementName2, displayFlag, statusMessage) {
    if (elementName1) {
        var element1 = document.getElementById(elementName1);
    }
    if (elementName2) {
        var element2 = document.getElementById(elementName2);
    }

    if (displayFlag) {
        if (element2) {
            element2.innerText = statusMessage;
        }
        if (element1) {
            element1.style.display = 'block';
        }
    }
    else {
        if (element2) {
            element2.innerText = '';
        }
        if (element1) {
            element1.style.display = 'none';
        }
    }
}
