//From: https://github.com/abergs/fido2-net-lib

//************** mfa.register ******************
async function createRegisterWebAuth() {
    let dataWebAuth;
    try {
        dataWebAuth = await Promise.resolve($.post(quidgestGlobals.UrlAction.MkCredWebAuth, $.param({}, true)));
    } catch (e) {
        console.error(e);
    }

    console.log("Credential Options Object", dataWebAuth);
    dataWebAuth.options = JSON.parse(dataWebAuth.options);
    if (dataWebAuth.options.status !== "ok") {
        console.log("Error creating credential options");
        return;
    }

    // Turn the challenge back into the accepted format of padded base64
    dataWebAuth.options.challenge = coerceToArrayBuffer(dataWebAuth.options.challenge);
    // Turn ID into a UInt8Array Buffer for some reason
    dataWebAuth.options.user.id = coerceToArrayBuffer(dataWebAuth.options.user.id);

    dataWebAuth.options.excludeCredentials = dataWebAuth.options.excludeCredentials.map((c) => {
        c.id = coerceToArrayBuffer(c.id);
        return c;
    });

    if (dataWebAuth.options.authenticatorSelection.authenticatorAttachment === null) dataWebAuth.options.authenticatorSelection.authenticatorAttachment = undefined;

    /*bootbox.dialog({
        title: "Registering...",
        message: "Tap your security key to finish registration."
    });*/

    console.log("Creating PublicKeyCredential...");

    let newCredential;
    try {
        newCredential = await navigator.credentials.create({
            publicKey: dataWebAuth.options
        });
    } catch (e) {
        var msg = "Could not create credentials in browser. Probably because the username is already registered with your authenticator. Please change username or authenticator."
        console.error(msg, e);
        showErrorAlert(msg, e);
    }


    console.log("PublicKeyCredential Created", newCredential);

    try {
        registerNewCredential(newCredential);

    } catch (e) {
        showErrorAlert(err.message ? err.message : err);
    }
}

// This should be used to verify the auth data with the server
async function registerNewCredential(newCredential) {
    // Move data into Arrays incase it is super long
    let attestationObject = new Uint8Array(newCredential.response.attestationObject);
    let clientDataJSON = new Uint8Array(newCredential.response.clientDataJSON);
    let rawId = new Uint8Array(newCredential.rawId);

    const data = {
        id: newCredential.id,
        rawId: coerceToBase64Url(rawId),
        type: newCredential.type,
        extensions: newCredential.getClientExtensionResults(),
        response: {
            AttestationObject: coerceToBase64Url(attestationObject),
            clientDataJson: coerceToBase64Url(clientDataJSON)
        }
    };

    let response;
    try {
        response = await Promise.resolve($.post({
            type: 'POST',
            url: quidgestGlobals.UrlAction.MkCredWebAuth2,
            data: { data: JSON.stringify(data) }
        }));
    } catch (e) {
        console.error(e);
    }

    console.log("Credential Object", response);

    // show error
    if (!response.Success) {
        bootbox.alert("Error creating credential");
        return;
    }

    // show success 
    bootbox.dialog({
        title: "Registration Successful!",
        message: "You\'ve registered successfully.",
        timeOut: 2000
    });
}

//************** mfa.login ******************
async function handleSignInWebAuth(returnData) {
    // send to server for registering
    let makeAssertionOptions;
    try {
        let response;
        response = await Promise.resolve($.post(quidgestGlobals.UrlAction.AssertionWebAuth, $.param({}, true)));
        makeAssertionOptions = JSON.parse(response.options);
    } catch (e) {
        showErrorAlert("Request to server failed", e);
    }

    console.log("Assertion Options Object", makeAssertionOptions);

    // show options error to user
    if (makeAssertionOptions.status !== "ok") {
        console.log("Error creating assertion options");
        console.log(makeAssertionOptions.errorMessage);
        showErrorAlert(makeAssertionOptions.errorMessage);
        return;
    }

    // todo: switch this to coercebase64
    const challenge = makeAssertionOptions.challenge.replace(/-/g, "+").replace(/_/g, "/");
    makeAssertionOptions.challenge = Uint8Array.from(atob(challenge), c => c.charCodeAt(0));

    // fix escaping. Change this to coerce
    makeAssertionOptions.allowCredentials.forEach(function (listItem) {
        var fixedId = listItem.id.replace(/\_/g, "/").replace(/\-/g, "+");
        listItem.id = Uint8Array.from(atob(fixedId), c => c.charCodeAt(0));
    });

    console.log("Assertion options", makeAssertionOptions);

    // ask browser for credentials (browser will ask connected authenticators)
    let credential;
    try {
        credential = await navigator.credentials.get({ publicKey: makeAssertionOptions })
    } catch (err) {
        bootbox.alert(err.message ? err.message : err);
    }

    try {
        let authData = new Uint8Array(credential.response.authenticatorData);
        let clientDataJSON = new Uint8Array(credential.response.clientDataJSON);
        let rawId = new Uint8Array(credential.rawId);
        let sig = new Uint8Array(credential.response.signature);
        const data = {
            id: credential.id,
            rawId: coerceToBase64Url(rawId),
            type: credential.type,
            extensions: credential.getClientExtensionResults(),
            response: {
                authenticatorData: coerceToBase64Url(authData),
                clientDataJson: coerceToBase64Url(clientDataJSON),
                signature: coerceToBase64Url(sig)
            }
        };

        let response = await Promise.resolve($.post({
            type: 'POST',
            url: quidgestGlobals.UrlAction.AssertionWebAuth2,
            data: {
                data: JSON.stringify(data),
                returnUrl: returnData.Redirect
            }
        }));

        loginSuccess(response);
    } catch (e) {
        console.log("Could not verify assertion: " + e);
    }
}


//************** HELPERS **************
coerceToArrayBuffer = function (thing, name) {
    if (typeof thing === "string") {
        // base64url to base64
        thing = thing.replace(/-/g, "+").replace(/_/g, "/");

        // base64 to Uint8Array
        var str = window.atob(thing);
        var bytes = new Uint8Array(str.length);
        for (var i = 0; i < str.length; i++) {
            bytes[i] = str.charCodeAt(i);
        }
        thing = bytes;
    }

    // Array to Uint8Array
    if (Array.isArray(thing)) {
        thing = new Uint8Array(thing);
    }

    // Uint8Array to ArrayBuffer
    if (thing instanceof Uint8Array) {
        thing = thing.buffer;
    }

    // error if none of the above worked
    if (!(thing instanceof ArrayBuffer)) {
        throw new TypeError("could not coerce '" + name + "' to ArrayBuffer");
    }

    return thing;
};


coerceToBase64Url = function (thing) {
    // Array or ArrayBuffer to Uint8Array
    if (Array.isArray(thing)) {
        thing = Uint8Array.from(thing);
    }

    if (thing instanceof ArrayBuffer) {
        thing = new Uint8Array(thing);
    }

    // Uint8Array to base64
    if (thing instanceof Uint8Array) {
        var str = "";
        var len = thing.byteLength;

        for (var i = 0; i < len; i++) {
            str += String.fromCharCode(thing[i]);
        }
        thing = window.btoa(str);
    }

    if (typeof thing !== "string") {
        throw new Error("could not coerce to string");
    }

    // base64 to base64url
    // NOTE: "=" at the end of challenge is optional, strip it off here
    thing = thing.replace(/\+/g, "-").replace(/\//g, "_").replace(/=*$/g, "");

    return thing;
};