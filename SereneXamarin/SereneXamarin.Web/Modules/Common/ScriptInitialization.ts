var g_currentGrid: Serenity.EntityGrid<any, any>;

namespace SereneXamarin.ScriptInitialization {
    Q.Config.responsiveDialogs = true;
    Q.Config.rootNamespaces.push('SereneXamarin');

    window.onhashchange = (ev) => {
        let newURL = ev.newURL.split('#');

        if (newURL.length > 0) {
            let hash = newURL[1];
            let hash2 = hash.split('/');
            let moduleName = hash2[0];
            let gridName = hash2[1] + 'Grid';

            let gridContainer = $('#GridDiv');

            if (g_currentGrid && g_currentGrid.destroy) g_currentGrid.destroy();
            g_currentGrid = new SereneXamarin[moduleName][gridName](gridContainer);

            Q.initFullHeightGridPage(gridContainer);

        }
    };
}