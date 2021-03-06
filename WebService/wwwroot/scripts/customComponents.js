﻿require(["knockout"], function (ko) {
    ko.components.register("wordCloud",
        {
            viewModel: { require: "../scripts/components/wordCloud/wordCloud" },
            template: { require: "text!../scripts/components/wordCloud/wordCloud.html" }
        }
    );
    ko.components.register("post",
        {
            viewModel: { require: "../scripts/components/singlePost/singlePost" },
            template: { require: "text!../scripts/components/singlePost/singlePost.html" }
        }
    );
    ko.components.register("searchList",
        {
            viewModel: { require: "../scripts/components/searchList/searchList" },
            template: { require: "text!../scripts/components/searchList/searchList.html" }
        }
    );
    ko.components.register("searchListItem",
        {
            viewModel: { require: "../scripts/components/searchListItem/searchListItem" },
            template: { require: "text!../scripts/components/searchListItem/searchListItem.html" }
        }
    );
    ko.components.register("forceNetwork",
        {
            viewModel: { require: "../scripts/components/forceNetwork/forceNetwork" },
            template: { require: "text!../scripts/components/forceNetwork/forceNetwork.html" }
        }
    );

    ko.components.register("history",
        {
            viewModel: { require: "../scripts/components/history/history" },
            template: { require: "text!../scripts/components/history/history.html" }
        }
    );

    ko.components.register("favorites",
        {
            viewModel: { require: "../scripts/components/favorites/favorites" },
            template: { require: "text!../scripts/components/favorites/favorites.html" }
        }
    );
    //TODO Add force network component
});