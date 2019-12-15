# WPExportContent
Export Content From WP 

## Solutions

### WPExportContent.WebUI.sln
NetCore3 & MVC Web Solution - Export WP Blog from UI (minimal) Interface 

### WPExportContent.sln
NetCore console app - fast test with appsettings.json for setting

####  WPExportContent - appsettings.json

```

{
	"PluginExport": {
		"WooCommerce": true,
		"Yoast": true
	},
	"WPSource": {
		"DB_NAME": "wpexportcontent",
		"DB_USER": "root",
		"DB_PASSWORD": "",
		"DB_HOST": "localhost",
		"TABLE_PREFIX": "wpej_"
	},
	"OUTFile": {
		"DirtyExportFile": "z:\\wpDirtyExportFile.json",
		"ExportFile": "z:\\wpExportFile.json",
		"SQLServerConnection": "",
		"MySQLServerConnection": "Server=XXX;Database=XXX;Uid=XXX;Pwd=XXX;Port=3306"
	}

}

```

PluginExport / WooCommerce : set "true" if you want to export products (no orders)
