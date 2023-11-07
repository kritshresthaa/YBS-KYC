/*document.getElementById("captureFingerprintButton").addEventListener("click", function () {
    // Send an AJAX request to the CaptureFingerprint action
    fetch('/Home/CaptureFingerprint', {
        method: 'POST', // Use the POST method
        headers: {
            'Content-Type': 'application/json', // Set the content type
        },
    })
        .then(response => response.json()) // Parse the JSON response
        .then(data => {
            if (data.success) {
                // Handle success, e.g., update UI with the captured data
                console.log("Fingerprint captured successfully");
                console.log(data.FingerprintData); // You can access the fingerprint data here
            } else {
                // Handle failure, e.g., display an error message
                console.error("Fingerprint capture failed: " + data.errorMessage);
            }
        })
        .catch(error => {
            // Handle any errors, e.g., display an error message
            console.error("Error capturing fingerprint: " + error);
        });
});
*/

document.getElementById("leftCaptureFingerprintButton").addEventListener("click", function () {
    // Capture the left fingerprint
    fetch('/Home/CaptureLeftFingerprint', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                console.log("Left fingerprint captured successfully from the js");
                console.log(data.FingerprintData);
                // Update UI or handle the captured data as needed
            } else {
                console.error("Left fingerprint capture failed: " + data.errorMessage);
            }
        })
        .catch(error => {
            console.error("Error capturing left fingerprint: " + error);
        });
});

document.getElementById("rightCaptureFingerprintButton").addEventListener("click", function () {
    // Capture the right fingerprint
    fetch('/Home/CaptureRightFingerprint', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                console.log("Right fingerprint captured successfully");
                console.log(data.FingerprintData);
                // Update UI or handle the captured data as needed
            } else {
                console.error("Right fingerprint capture failed: " + data.errorMessage);
            }
        })
        .catch(error => {
            console.error("Error capturing right fingerprint: " + error);
        });
});
