const apiUrl = "";
const submitButton = document.getElementById("form-submit");
const parkingForm = document.getElementById("parking-form");
var loadingFlag = false;

// Event listener that listens for clicks on the form submit button.
// When a click is heard, an API request gets sent with current form data
// and the page gets updated when the request returns.
submitButton.addEventListener("click", (e) => {

    if (!loadingFlag) {

        loadingFlag = true;
        addSpinner();

        // send and handle resullt of api call
    }
    else {
        clearSpinner();
        loadingFlag = false;
    }
});

// Remove content from the submit button and add a loading spinner and text
function addSpinner() {

    while (submitButton.firstChild) {
        submitButton.removeChild(submitButton.firstChild);
    }

    let spinner = document.createElement("span");
    spinner.classList.add("spinner-border");
    spinner.classList.add("spinner-border-sm");

    let loadingText = document.createTextNode("Loading...");

    submitButton.appendChild(spinner);
    submitButton.appendChild(loadingText);
}

// Remove content from the submit button and add submit text
function clearSpinner() {

    while (submitButton.firstChild) {
        submitButton.removeChild(submitButton.firstChild);
    }

    let submitText = document.createTextNode("Submit");
    submitButton.appendChild(submitText);
}

// Send a request to the API URL and handle the response
function sendRequest() {
    let response = await fetch(apiUrl, {
        body: new FormData(parkingForm)
    });

    if (response.ok) {
        // load response data into the page
    }
    else {
        // say that there was an error
    }
}