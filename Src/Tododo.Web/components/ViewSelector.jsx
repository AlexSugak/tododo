/** @jsx React.DOM */

var React = require("react");

var IndexView = require("./IndexView");

var ViewSelector = React.createClass({
	propTypes: {
		page: React.PropTypes.string.isRequired,
	},

	loadView: function(page) {
		if (page === "index") {
			return <IndexView />;
		}

		return (<div>{page}</div>);
	},

	render: function render() {
		var view = this.loadView(this.props.page);
		return view;
	}
});


module.exports = ViewSelector;