import React from 'react'

const sortArray = (array, { key, direction }) => {
    return array.sort((a, b) => {
        if (a[key] < b[key]) return direction === 'ascending' ? -1 : 1
        if (a[key] > b[key]) return direction === 'ascending' ? 1 : -1
        return 0
    })
}

const sortHook = (items = [], config) => {
    const [sortConfig, setSortConfig] = React.useState(config)

    const sortedItems = React.useMemo(() => {
        if (!sortConfig)
            return items

        return sortArray(items, { ...sortConfig })
    }, [items, sortConfig])

    const requestSort = key => {
        let direction = 'ascending'

        if (
            sortConfig &&
            sortConfig.key === key &&
            sortConfig?.direction === 'ascending'
        ) {
            direction = 'descending'
        }

        setSortConfig({ key, direction })
    }

    return { items: sortedItems, requestSort, sortConfig }
}

export const SortButton = ({ id, sortConfig, onClick }) => {
    return (
    <div>
        {id}
            <button className="btn btn-light text-info p-0 px-1 pb-1" id={id} onClick={onClick}>
                {
                    sortConfig?.key === id ? sortConfig?.direction === 'ascending'
                        ? '\u25BC' // ▲
                        : '\u25B2' // ▼
                        : '\u21C5' // ⇅
                }
            </button>
        </div>
    )
}

export default sortHook