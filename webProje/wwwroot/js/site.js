// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
<script>
    var
            filters = {
        tur: null,
                cap: null,
                materyal: null
            };

        function updateFilters() {
        $('.task-list-row').hide().filter(function () {
            var
                self = $(this),
                result = true; // not guilty until proven guilty

            Object.keys(filters).forEach(function (filter) {
                if (filters[filter] && (filters[filter] != 'Hepsi') && (filters[filter] != 'Any')) {
                    result = result && filters[filter] === self.data(filter);
                }
            });

            return result;
        }).show();
        }

        function changeFilter(filterName) {
        filters[filterName] = this.value;
            updateFilters();
        }

        // Assigned User Dropdown Filter
        $('#kullanimAlani-filter').on('change', function () {
        changeFilter.call(this, 'tur');
        });
        $('#jantCapi-filter').on('change', function () {
        changeFilter.call(this, 'cap');
        });
        $('#materyal-filter').on('change', function () {
        changeFilter.call(this, 'materyal');
        });


        /*
        future use for a text input filter
        $('#search').on('click', function() {
        $('.box').hide().filter(function () {
            return $(this).data('order-number') == $('#search-criteria').val().trim();
        }).show();
        });*/

    </script>