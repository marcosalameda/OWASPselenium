/*************************
* Quidgest Local Storage *
*************************/
QLocalStorage = {
    getNav: function () {
        if (window.name.length == 0) return "Q"; else return window.name;
    },
    /**
     * Get Timestamp for history
     * @param {Number} msTtl Number of milliseconds (default: 45 min)
     * @returns The number of milliseconds
     */
    getTimestamp: function (msTtl) {
        msTtl = msTtl || 1000 * 60 * 45; // 45 min
        return Date.now() + msTtl;
    },
    /**
     * Check if the Time to Live is not expired
     * @param {Number} timestamp The timestamp (number of milliseconds)
     * @returns Returns true if the TTL (time to live) is not yet expired
     */
    CheckTTL: function (timestamp) {
        if(!timestamp || typeof timestamp !== 'number')
            return false;
        return (timestamp || 0) > Date.now();
    },
    localStorageCheckTTL: function () {
        let countGS = localStorage["TimestampAccessCount"] || 0;
        countGS = countGS - 1;
        if (countGS <= 0) {
            let Timestamps = JSON.parse(localStorage["Timestamps"] || '{}'),
                timestampsKeysToCheck = Object.keys(Timestamps),
                QLocalStorageObj = this;

            //Check Timestamps list
            $.each(timestampsKeysToCheck, function(_, navigationId) {
                if (!QLocalStorageObj.CheckTTL(Timestamps[navigationId]))
                    delete Timestamps[navigationId];
            });

            // Update current navigation timestamp (TTL: 12 min)
            Timestamps[this.getNav()] = this.getTimestamp();

            // Check all localStorage elements
            let validStorageNavId = Object.keys(Timestamps);
            // TODO: Why it's not a array ?? 
            let storageNames = { 0: "savedInfo", 3: "selections", 4: "accordions", 5: "collapsible", 6: "lastActiveElement", 7: "TableSelections", 8: "Tab", 9: "LastTableSelections", 10: "ribbon_selectedTabIndex", 11: "sidebar_selectedMenu", 12: "LastTabSelected", 13: "sidebar_selectedItemMenu", 14: "reportingMode", 15: "rigthsidebaropen", 16: "rigthsidebarnavclosed", 17: "TableAllSelected", 18: "ExportValidationOverride"};

            $.each(storageNames, function (_, storageName) {
                var storage = JSON.parse(localStorage[storageName] || '{}'),
                    storageNavIds = Object.keys(storage);

                    $.each(storageNavIds, function(_, navigationId) {
                        if(!validStorageNavId.includes(navigationId))
                            delete storage[navigationId];
                    });
                    localStorage.setItem(storageName, JSON.stringify(storage));
            });
            // Update Timestamps list
            localStorage.setItem("Timestamps", JSON.stringify(Timestamps));
            //after 20 get's/set's check localStorage. (don't need doing this every time -> performance)
            countGS = 20;
        }
        localStorage.setItem("TimestampAccessCount", countGS);
    },
    getLocalStorage: function (ls) {
        let storage = JSON.parse(localStorage[ls] || '{}'),
            storageValue = storage[this.getNav()] || {};

        this.localStorageCheckTTL();
        return storageValue;
    },
    setLocalStorage: function (ls, val) {
        let storage = JSON.parse(localStorage[ls] || '{}');
        storage[this.getNav()] = val;
        localStorage.setItem(ls, JSON.stringify(storage));

        this.localStorageCheckTTL();
    },
    chkLocalStorage: function (ls) {
        let storage = JSON.parse(localStorage[ls] || '{}');
        return !$.isEmptyObject(storage[this.getNav()] || null);
    },
    _remLocalStorage: function (ls, wId) {
        //Eliminar o determinado localStorage pelo Id da janela
        let storage = JSON.parse(localStorage[ls] || '{}');
        delete storage[wId];
        localStorage.setItem(ls, JSON.stringify(storage))
    },
    remLocalStorage: function (ls) {
        //Eliminar o determinado localStorage da janela atual
        this._remLocalStorage(ls, this.getNav());
        this.localStorageCheckTTL();
    },
    refreshLSTimestamp: function (newGuid) {
        //Create timestamp
        let Timestamps = JSON.parse(localStorage["Timestamps"] || '{}');
        Timestamps[newGuid] = this.getTimestamp();
        localStorage.setItem("Timestamps", JSON.stringify(Timestamps));
    },
    removeEntry: function(area, field, key) {
        if (key === undefined || area === undefined || field === undefined)
            return;
        area = area.toLowerCase();
        let storage = this.getLocalStorage('savedInfo');
        
        if(((storage[area] || {})[key] || {})[field])
            delete storage[area][key][field];

        this.setLocalStorage('savedInfo', storage);
    },
    setEntry: function (area, field, newValue, key, formName) {
        if (formName === undefined || key === undefined || area === undefined || field === undefined)
            return;
        area = area.toLowerCase();
        let storage = this.getLocalStorage('savedInfo');

        if (storage[area] === undefined)
            storage[area] = {};
        if (storage[area][key] === undefined)
            storage[area][key]= {};

        if (storage[area][key][field] === undefined)
            storage[area][key][field] = { value: newValue, original: null, form: formName };
        
        storage[area][key][field].value = newValue;
        storage[area][key][field].form = formName;

        this.setLocalStorage('savedInfo', storage);
    },
    getEntry: function (area, field, key) {
        if (key === undefined || area === undefined || field === undefined)
            return;
        let storage = this.getLocalStorage('savedInfo');
        return ((storage[area] || {})[key] || {})[field];
    },
    __getGroupByIdentifier: function (localStorageIdentifier, groupIdentifier, emptyObject) {
        var obj = QLocalStorage.getLocalStorage(localStorageIdentifier);
        if ($.isEmptyObject(obj))
            return emptyObject;
        return obj[groupIdentifier] || emptyObject;
    },
    __setGroupByIdentifier: function (localStorageIdentifier, groupIdentifier, data) {
        var obj = QLocalStorage.getLocalStorage(localStorageIdentifier);
        obj[groupIdentifier] = data;
        QLocalStorage.setLocalStorage(localStorageIdentifier, obj);
    },
    getTableSelections: function (tableIdentifier) {
        return QLocalStorage.__getGroupByIdentifier('TableSelections', tableIdentifier, { Selections: {} });
    },
    setTableSelections: function (tableIdentifier, data) {
        QLocalStorage.__setGroupByIdentifier('TableSelections', tableIdentifier, data || { Selections: {} });
    },
    getLastTableSelections: function (tableIdentifier) {
        return QLocalStorage.__getGroupByIdentifier('LastTableSelections', tableIdentifier, { Selections: {} });
    },
    setLastTableSelections: function (tableIdentifier, data) {
        QLocalStorage.__setGroupByIdentifier('LastTableSelections', tableIdentifier, data || { Selections: {} });
    },
    getTableAllSelected: function (tableIdentifier) {
        return QLocalStorage.__getGroupByIdentifier('TableAllSelected', tableIdentifier, false);
    },
    setTableAllSelected: function (tableIdentifier, allSelected) {
        QLocalStorage.__setGroupByIdentifier('TableAllSelected', tableIdentifier, allSelected || false);
    }
};