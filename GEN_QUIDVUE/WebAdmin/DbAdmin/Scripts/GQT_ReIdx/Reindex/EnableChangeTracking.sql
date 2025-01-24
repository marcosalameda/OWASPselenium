-- ================================================
--              ENABLE CHANGE TRACKING
-- ================================================
-- This enables change tracking for the database
-- and then for the requested tables.
--
-- No changes to the table definitions are required,
-- and no triggers are created during this process.
-- ================================================

BEGIN TRY
	-- Snapshot isolation must be enabled for the database. 
	-- All the steps that are required to obtain changes must be included inside a snapshot transaction.
	ALTER DATABASE [W_GnBD]
	SET ALLOW_SNAPSHOT_ISOLATION ON;

    -- First enable change tracking at the database level
    IF NOT EXISTS (SELECT 1 FROM sys.change_tracking_databases WHERE database_id = DB_ID('W_GnBD'))
    BEGIN
        ALTER DATABASE [W_GnBD]
        SET CHANGE_TRACKING = ON (AUTO_CLEANUP = OFF);
    END

    USE [W_GnBD]

    -- Get all tables that need change tracking enabled in one query
    CREATE TABLE #TablesNeedingTracking (
        table_name sysname
    );

    INSERT INTO #TablesNeedingTracking (table_name)
    SELECT t.name
    FROM sys.tables t
    LEFT JOIN sys.change_tracking_tables ct ON t.object_id = ct.object_id
    WHERE ct.object_id IS NULL  -- Tables without change tracking
    AND t.name IN (
        'GQPAddress', 'GQTADDRL', 'GQTAERO', 'GQTAFINI', 'GQTAGENT', 'GQTAGREG', 'GQTAIRLN', 'GQTAIRPL',
        'GQTAIRPT', 'GQTANEXD', 'GQTAsset', 'GQTAssetManual', 'GQTAssetParameter', 'GQTAttachment', 'GQTAUDIT', 'GQTBRDPS',
        'GQTCategorias', 'GQTCATTP', 'GQTCFAQS', 'GQTCITY', 'GQTCMPKI', 'GQTCMPNY', 'GQTCNTRY', 'GQTCONTA',
        'GQTCTRY', 'GQTDECOM', 'GQTDESAM', 'GQTDispatchLine', 'GQTDispatch', 'GQTDataTypes', 'GQTEntity', 'GQTEQUIP',
        'GQTESPPE', 'GQTEVCAT', 'GQTEXPEN', 'GQTFacility', 'GQTFacilityType', 'GQTFAMIL', 'GQTFAQS', 'GQTFEECA',
        'GQTFLDS', 'GQTFLIGH', 'GQTFLTSC', 'GQTFTGRI', 'GQTGAMES', 'GQTGENRE', 'GQTGITEM', 'GQTGLOB',
        'GQTGRID', 'GQTGRPB', 'GQTHPESS', 'GQTINDOC', 'GQTINPGR', 'GQTINSTA', 'GQTITEM', 'GQTITEMC',
        'GQTITEMP', 'GQTKindOfEquipment', 'GQTLANGU', 'GQTLocationExtension', 'GQTLDENT', 'GQTLENDI', 'GQTLNHAG', 'GQTLNHDE',
        'GQTLNHDF', 'GQTLNHPD', 'GQTLocation', 'GQTManualToCollect', 'GQTMEM', 'GQTMessages', 'GQTMOVIM', 'GQTNOTIF',
        'GQTORGAN', 'GQTOUDOC', 'GQTOUTPT', 'GQTOUTPU', 'GQTParameter', 'GQTPEDID', 'GQTPeriod', 'GQTPerson',
        'GQTPessoas', 'GQTPHOTO', 'GQTPROCN', 'GQTProduct', 'GQTPROJE', 'GQTPROPE', 'GQTPROPH', 'GQTPROPR',
        'GQTPRPIN', 'GQTPSNGR', 'UserLogin', 'GQTPWCOM', 'GQTPWORG', 'GQTPWREG', 'GQTReceipt', 'GQTREGIO',
        'GQTREGIS', 'GQTReceiptLine', 'GQTREPAR', 'GQTROGL1', 'GQTROIGF', 'GQTROIGI', 'GQTROLE', 'GQTROOMS',
        'GQTRORDF', 'GQTRORDI', 'GQTRULES', 'AsyncProcess', 'AsyncProcessArgument', 'NotificationEmailSignature', 'NotificationMessage', 'AsyncProcessAttachments',
        'UserAuthorization', 'GQTSALE', 'GQTSALES', 'GQTSBCAT', 'GQTSHITY', 'GQTSPACE', 'GQTSPECI', 'GQTSTAKE',
        'GQTSTRAT', 'GQTTABPR', 'GQTTBLB', 'GQTTBLK', 'GQTTEAMP', 'GQTTICKT', 'GQTTPCON', 'GQTTPEQU',
        'GQTTPPRO', 'GQTTRADU', 'GQTTRSB', 'GQTUICOM', 'GQTUSERS', 'GQTVISIT', 'GQTWAREH', 'GQTWPESS',
        'GQTYEAR'    );

    -- Enable tracking for all needed tables in a cursor (to maintain error handling per table)
    DECLARE @tableName sysname;
    DECLARE @sql nvarchar(max);
    
    DECLARE table_cursor CURSOR FOR 
    SELECT table_name FROM #TablesNeedingTracking;
    
    OPEN table_cursor;
    FETCH NEXT FROM table_cursor INTO @tableName;
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @sql = 'ALTER TABLE [' + @tableName + '] ENABLE CHANGE_TRACKING WITH (TRACK_COLUMNS_UPDATED = ON);';
        EXEC sp_executesql @sql;
        
        PRINT 'Enabled change tracking for ' + @tableName;
        FETCH NEXT FROM table_cursor INTO @tableName;
    END
    
    CLOSE table_cursor;
    DEALLOCATE table_cursor;
    
    DROP TABLE #TablesNeedingTracking;

END TRY
BEGIN CATCH
    IF EXISTS (SELECT 1 FROM tempdb.sys.tables WHERE name LIKE '#TablesNeedingTracking%')
        DROP TABLE #TablesNeedingTracking;
    
    IF (SELECT CURSOR_STATUS('global','table_cursor')) >= -1
    BEGIN
        CLOSE table_cursor;
        DEALLOCATE table_cursor;
    END

    PRINT 'Error occurred while enabling change tracking:';
    PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(50));
    PRINT 'Error Message: ' + ERROR_MESSAGE();
    PRINT 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(50));
    THROW;
END CATCH
