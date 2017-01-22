var g_currentGrid: Serenity.EntityGrid<any, any>;

namespace SereneXamarin.ScriptInitialization {
    Q.Config.responsiveDialogs = true;
    Q.Config.rootNamespaces.push('SereneXamarin');

    let loadUrlHash = function () {
        if (location.hash.length > 1) {

            let hash2 = location.hash.substr(1).split('/');
            let moduleName = hash2[0];
            let gridName = hash2[1] + 'Grid';

            let gridContainer = $('#GridDiv');

            if (g_currentGrid && g_currentGrid.destroy) g_currentGrid.destroy();
            g_currentGrid = new SereneXamarin[moduleName][gridName](gridContainer);

            Q.initFullHeightGridPage(gridContainer);
        }
    };

    window.onhashchange = (ev) => {
        loadUrlHash();
    }
    window.onload = (ev) => {
        loadUrlHash();
    };

}