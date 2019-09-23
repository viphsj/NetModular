/** 页面信息 */
const page = new (function() {
  this.title = '区划代码管理'
  this.icon = 'area'
  this.name = 'common_area'
  this.path = '/common/area'

  // 关联权限
  this.permissions = [
    `${this.name}_query_get`,
    `${this.name}_querychildren_get`
  ]

  this.buttons = {
    add: {
      text: '添加',
      type: 'success',
      icon: 'add',
      code: `${this.name}_add`,
      permissions: [`${this.name}_add_post`]
    },
    edit: {
      text: '编辑',
      type: 'text',
      icon: 'edit',
      code: `${this.name}_edit`,
      permissions: [`${this.name}_edit_get`, `${this.name}_update_post`]
    },
    del: {
      text: '删除',
      type: 'text',
      icon: 'delete',
      code: `${this.name}_del`,
      permissions: [`${this.name}_delete_delete`]
    }
  }
})()

/** 路由信息 */
export const route = {
  page,
  component: () => import(/* webpackChunkName: "Common.Area" */ './index')
}

export default page
